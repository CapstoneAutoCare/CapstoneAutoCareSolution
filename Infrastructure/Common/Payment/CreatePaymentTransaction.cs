using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Payment
{
    public class CreatePaymentTransaction
    {
        public Guid MaintenanceCenterId { get; set; }
        public Guid MaintenancePlanId { get; set; }
        public Guid VehiclesId { get; set; }
        public string FullName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
