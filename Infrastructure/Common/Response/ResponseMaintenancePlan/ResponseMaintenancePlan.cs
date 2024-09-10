using Infrastructure.Common.Response.ReponseVehicleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Response.ResponseMaintenancePlan
{
    public class ResponseMaintenancePlan
    {
        public Guid MaintenancePlanId { get; set; }
        public string MaintenancePlanName { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime DateTime { get; set; }
        public ReponseVehicleModels ReponseVehicleModels { get; set; }
    }
}
