using Infrastructure.Common.Payment;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Infrastructure.Common.Payment.PayPalSeal;

namespace Infrastructure.IService
{
    public interface IPaymentPayPalService
    {
        Task<CreateOrderResponse> CreateOrder(string value, string currency, Guid reference);
        Task<CaptureOrderResponse> CaptureOrder(string orderId);

        Task<string> CreatePaymentUrl(HttpContext context, VnPaymentRequest model);
        Task<VnPaymentResponse> PaymentExecute(string url);


    }
}
