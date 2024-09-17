using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Payment
{
    public class ResonseVnpaymentTransaction
    {
        public bool Success { get; set; }
        public string PaymentMethod { get; set; }
        public string OrderDescription { get; set; }
        public string OrderId { get; set; }
        public string TransactionId { get; set; }
        public string VnPayResponseCode { get; set; }
    }
}
