using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.RequestMaintenanceTechinican
{
    public class CreateMaintenanceTaskServiceInfo
    {
        public Guid MaintenanceTaskId { get; set; }
        public Guid MaintenanceServiceInfoId { get; set; }
    }
}
