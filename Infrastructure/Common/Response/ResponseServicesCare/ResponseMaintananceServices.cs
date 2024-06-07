using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Response.ResponseServicesCare
{
    public class ResponseMaintananceServices
    {
        public Guid MaintenanceServiceId { get; set; }
        public string ServicesCareName { get; set; }
        public double OriginalCost { get; set; }
        public double ActuralCost { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid ServiceCareId { get; set; }
        public Guid MaintenanceCenterId { get; set; }
        public string MaintenanceCenterName { get; set; }
    }
}
