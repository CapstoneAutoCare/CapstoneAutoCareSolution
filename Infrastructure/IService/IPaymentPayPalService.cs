using Infrastructure.Common.Payment;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Infrastructure.Common.Payment.PayPalSeal;
using static Infrastructure.IService.Imp.BookingServiceImp;

namespace Infrastructure.IService
{
    public interface IPaymentPayPalService
    {
        Task<CreateOrderResponse> CreateOrder(string value, string currency, Guid reference);
        Task<CaptureOrderResponse> CaptureOrder(string orderId);

        Task<string> CreatePaymentUrl(HttpContext httpContext, VnPaymentRequest model);
        Task<string> CreatePaymentUrlCenter(HttpContext httpContext);

        Task<VnPaymentResponse> PaymentExecute(IQueryCollection  values);

        Task<string> PaymentExecutev1(IQueryCollection queryParameters);
        Task<string> PaymentExecutev2(IQueryCollection queryParameters);

    }
}
