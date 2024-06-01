using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.RequestImageRepairReceipt
{
    public class CreateImageRepairReceipt
    {
        public string? Image { get; set; }
        public DateTime Created { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public Guid VehicleId { get; set; }
        public Guid? MaintenanceCenterId { get; set; }
    }
}
