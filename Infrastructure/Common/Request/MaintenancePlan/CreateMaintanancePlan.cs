using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.MaintenancePlan
{
    public class CreateMaintanancePlan
    {
        public string MaintenancePlanName { get; set; }
        public string MaintenancePlanDescription { get; set; }
        public Guid MaintananceScheduleId { get; set; }
    }
}
