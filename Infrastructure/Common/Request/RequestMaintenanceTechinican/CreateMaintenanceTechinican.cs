using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.RequestMaintenanceTechinican
{
    public class CreateMaintenanceTechinican
    {
        public Guid InformationMaintenanceId { get; set; }
        public Guid TechnicianId { get; set; }
        public string MaintenanceTaskName { get; set; }
    }
}
