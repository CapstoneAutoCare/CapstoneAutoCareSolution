using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.MaintenancePlan
{
    public class CreateMaintanancePlan
    {
        public Guid VehicleModelId { get; set; }
        public string MaintenancePlanName { get; set; }
        public string Description { get; set; }

    }
}
