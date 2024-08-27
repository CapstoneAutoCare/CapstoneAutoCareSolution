using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request
{
    public class CreateTransaction
    {
        public float Amount { get; set; }
        public string PaymentMethod { get; set; }
    }
}
