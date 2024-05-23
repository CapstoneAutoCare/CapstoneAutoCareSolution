using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.MaintananceServices
{
    public class CreateMaintananceServices
    {
        public Guid MaintenanceServiceId { get; set; }
        public double ActuralCost { get; set; }
        public string Status { get; set; }
        public Guid ServiceCareId { get; set; }
        public Guid MaintenanceCenterId { get; set; }
    }
}
