using Domain.Entities;
using Domain.Enum;
using Infrastructure.Common.Payment;
using Infrastructure.IUnitofWork;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using static Infrastructure.Common.Payment.PayPalSeal;
using static Infrastructure.IService.Imp.BookingServiceImp;

namespace Infrastructure.IService.Imp
{
    public class PaymentPayPalServiceImp : IPaymentPayPalService
    {
        private readonly PaymentPayPall _paymentPayPall;
        private readonly HttpClient _httpClient;
        private readonly ConfiVnPay _confiVnPay;
        private readonly VnPayLibrary _vnPayLibrary;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PaymentPayPalServiceImp(PaymentPayPall paymentPayPall, HttpClient httpClient, ConfiVnPay confiVnPay, VnPayLibrary vnPayLibrary, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _paymentPayPall = paymentPayPall;
            _httpClient = httpClient;
            _confiVnPay = confiVnPay;
            _vnPayLibrary = vnPayLibrary;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public string BaseUrl => _paymentPayPall.Model == "Live"
            ? "https://api-m.paypal.com"
            : "https://api-m.sandbox.paypal.com";

        private async Task<AuthResponse> Authenticate()
        {
            var auth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_paymentPayPall.ClientId}:{_paymentPayPall.AppSecret}"));

            var content = new List<KeyValuePair<string, string>>
            {
                new("grant_type", "client_credentials")
            };

            var request = new HttpRequestMessage
            {
                RequestUri = new Uri($"{BaseUrl}/v1/oauth2/token"),
                Method = HttpMethod.Post,
                Headers =
                {
                    { "Authorization", $"Basic {auth}" }
                },
                Content = new FormUrlEncodedContent(content)
            };

            var httpResponse = await _httpClient.SendAsync(request);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Failed to authenticate with PayPal");
            }

            var jsonResponse = await httpResponse.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<AuthResponse>(jsonResponse);

            return response ?? throw new Exception("Failed to deserialize authentication response");
        }

        public async Task<CaptureOrderResponse> CaptureOrder(string orderId)
        {
            var auth = await Authenticate();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", auth.access_token);

            var httpContent = new StringContent("", Encoding.Default, "application/json");

            var httpResponse = await _httpClient.PostAsync($"{BaseUrl}/v2/checkout/orders/{orderId}/capture", httpContent);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Failed to capture PayPal order");
            }

            var jsonResponse = await httpResponse.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<CaptureOrderResponse>(jsonResponse);

            return response ?? throw new Exception("Failed to deserialize capture order response");
        }

        public async Task<CreateOrderResponse> CreateOrder(string value, string currency, Guid reference)
        {
            var auth = await Authenticate();

            var request = new CreateOrderRequest
            {
                intent = "CAPTURE",
                purchase_units = new List<PurchaseUnit>
                {
                    new()
                    {
                        reference_id = reference.ToString(),
                        amount = new Amount
                        {
                            currency_code = currency,
                            value = value
                        }
                    }
                }
            };

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", auth.access_token);

            var httpResponse = await _httpClient.PostAsJsonAsync($"{BaseUrl}/v2/checkout/orders", request);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Failed to create PayPal order");
            }

            var jsonResponse = await httpResponse.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<CreateOrderResponse>(jsonResponse);

            return response ?? throw new Exception("Failed to deserialize create order response");
        }

        public async Task<string> CreatePaymentUrl(HttpContext httpContext, VnPaymentRequest model)
        {
            var tick = DateTime.Now.Ticks.ToString();
            var r = await _unitOfWork.ReceiptRepository.GetById(model.ReceiptId);

            _vnPayLibrary.AddRequestData("vnp_Version", _confiVnPay.Version);
            _vnPayLibrary.AddRequestData("vnp_Command", _confiVnPay.Command);
            _vnPayLibrary.AddRequestData("vnp_TmnCode", _confiVnPay.TmnCode);
            _vnPayLibrary.AddRequestData("vnp_Amount", (r.TotalAmount * 100000).ToString());

            _vnPayLibrary.AddRequestData("vnp_CreateDate", model.CreatedDate.ToString("yyyyMMddHHmmss"));
            _vnPayLibrary.AddRequestData("vnp_CurrCode", _confiVnPay.CurrCode);
            _vnPayLibrary.AddRequestData("vnp_IpAddr", Utils.GetIpAddress(httpContext));
            _vnPayLibrary.AddRequestData("vnp_Locale", _confiVnPay.Locale);

            _vnPayLibrary.AddRequestData("vnp_OrderInfo", "Thanh toán cho đơn hàng:" + model.ReceiptId);
            _vnPayLibrary.AddRequestData("vnp_OrderType", "other");

            string baseUrl = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}{httpContext.Request.PathBase}";
            string returnUrl = $"{baseUrl}/api/Payments/PaymentExecute/";
            _vnPayLibrary.AddRequestData("vnp_ReturnUrl", returnUrl);

            _vnPayLibrary.AddRequestData("vnp_TxnRef", tick);

            var paymentUrl = await _vnPayLibrary.CreateRequestUrl(_confiVnPay.BaseUrl, _confiVnPay.HashSecret);
            return paymentUrl;
        }

        public async Task<VnPaymentResponse> PaymentExecute(PaymentExecuteRequest url)
        {
            var queryParameters = _vnPayLibrary.GetQueryParameters(url.Uri);

            foreach (string key in queryParameters.AllKeys)
            {
                if (!string.IsNullOrEmpty(key) && key.StartsWith("vnp_"))
                {
                    _vnPayLibrary.AddResponseData(key, queryParameters[key]);
                }
            }

            var vnp_orderId = Convert.ToInt64(_vnPayLibrary.GetResponseData("vnp_TxnRef"));
            var vnp_TransactionId = Convert.ToInt64(_vnPayLibrary.GetResponseData("vnp_TransactionNo"));
            var vnp_SecureHash = queryParameters["vnp_SecureHash"];
            var vnp_ResponseCode = _vnPayLibrary.GetResponseData("vnp_ResponseCode");
            var vnp_OrderInfo = _vnPayLibrary.GetResponseData("vnp_OrderInfo");

            bool checkSignature = _vnPayLibrary.ValidateSignature(vnp_SecureHash, _confiVnPay.HashSecret);

            string vnpOrderInfo = queryParameters["vnp_OrderInfo"];

            string receiptId = vnpOrderInfo.Substring(vnpOrderInfo.LastIndexOf(":") + 1);
            Guid receiptIdd = Guid.Parse(receiptId);
            var r = await _unitOfWork.ReceiptRepository.GetById(receiptIdd);


            if (!checkSignature)
            {
                return new VnPaymentResponse
                {
                    Success = false
                };
            }


            if (vnp_ResponseCode == "00" && r.Status.Equals(EnumStatus.YETPAID.ToString()))
            {
                r.Status = EnumStatus.PAID.ToString();
                r.InformationMaintenance.Status = EnumStatus.PAID.ToString();
                await _unitOfWork.InformationMaintenance.Update(r.InformationMaintenance);
                await _unitOfWork.ReceiptRepository.Update(r);
                await _unitOfWork.Commit();
                return new VnPaymentResponse
                {
                    Success = true,
                    PaymentMethod = "VnPay",
                    OrderDescription = vnp_OrderInfo,
                    OrderId = vnp_orderId.ToString(),
                    TransactionId = vnp_TransactionId.ToString(),
                    Token = vnp_SecureHash,
                    VnPayResponseCode = vnp_ResponseCode,
                    ReceiptId = receiptIdd,
                };
            }
            else
            {
                throw new Exception("CHANGE STATUS NOT COMPLETE");
            }


        }
    }
}