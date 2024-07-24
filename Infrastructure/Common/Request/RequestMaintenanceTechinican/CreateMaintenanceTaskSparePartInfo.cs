using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.RequestMaintenanceTechinican
{
    public class CreateMaintenanceTaskSparePartInfo
    {
        public Guid MaintenanceTaskId { get; set; }
        public Guid MaintenanceSparePartInfoId { get; set; }
    }
}
