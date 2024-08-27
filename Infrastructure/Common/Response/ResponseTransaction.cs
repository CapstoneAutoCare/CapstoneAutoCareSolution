using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Response
{
    public class ResponseTransaction
    {
        public Guid TransactionsId { get; set; }
        public Guid CenterPackagesId { get; set; }
        public DateTime TransactionDate { get; set; }
        public float Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
    }
}
