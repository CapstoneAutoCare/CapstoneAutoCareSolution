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
        public Guid MaintenanceCenterId { get; set; }
        public Guid MaintenancePlanId { get; set; }
        public Guid VehiclesId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Volume { get; set; }
        public string? Description { get; set; }

        public float Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public MaintenanceCenter MaintenanceCenter { get; set; }
        public MaintenancePlan MaintenancePlan { get; set; }
        public Vehicles Vehicles { get; set; }
    }
}
