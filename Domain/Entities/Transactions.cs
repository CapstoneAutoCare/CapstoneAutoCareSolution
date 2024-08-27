using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Transactions
    {
        public Transactions() { }
        [Key]
        public Guid TransactionsId { get; set; }
        public Guid CenterPackagesId { get; set; }
        public DateTime TransactionDate { get; set; }
        public float Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string Status{ get; set; }
        public CenterPackages CenterPackages { get; set; }
    }
}
