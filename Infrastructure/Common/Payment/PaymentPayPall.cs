using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Payment
{
    public class PaymentPayPall
    {
        public string ClientId { get; set; }
        public string AppSecret { get; set; }
        public string Model { get; set; }
    }
}
