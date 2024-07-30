using Azure.Core;
using Infrastructure.Common.Payment;
using Infrastructure.Common.Request.RequestSparePartsItemCost;
using Infrastructure.Common.Response.ResponseCost;
using Infrastructure.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Infrastructure.Common.Payment.PayPalSeal;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentPayPalService _payPalService;

        public PaymentsController(IPaymentPayPalService payPalService)
        {
            _payPalService = payPalService;
        }
        [HttpPost]
        public async Task<ActionResult<CreateOrderResponse>> Post(CreateOrderRequest create)
        {
            return Ok(await _payPalService.CreateOrder(create.Value, create.Currency, Guid.NewGuid()));
        }
        [HttpPost]

        public async Task<ActionResult<CaptureOrderResponse>> CaptureOrder(string orderId)
        {
            var response = await _payPalService.CaptureOrder(orderId);
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<string>> CreateVnPayPaymentUrl(VnPaymentRequest vn)
        {
            var response = await _payPalService.CreatePaymentUrl(HttpContext, vn);
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<string>> PaymentExecute(string uri)
        {
            var response = await _payPalService.PaymentExecute(uri);
            return Ok(response);
        }
        public class CreateOrderRequest
        {
            public string Value { get; set; }
            public string Currency { get; set; }
        }

    }
}
