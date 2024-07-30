using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Payment
{
    public class ConfiVnPay
    {
        public string TmnCode { get; set; }
        public string HashSecret
        {
            get; set;
        }
        public string BaseUrl { get; set; }
        public string Version { get; set; }
        public string Command { get; set; }
        public string CurrCode { get; set; }
        public string Locale { get; set; }
        public string PaymentBackReturnUrl { get; set; }

    }
}
