using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.RequestMaintenanceServiceCost
{
    public class CreateMaintenanceServiceCost
    {
        public double ActuralCost { get; set; }
        public string? Note { get; set; }
        public Guid MaintenanceServiceId { get; set; }
    }
}
