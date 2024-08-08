using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.MaintananceServices
{
    public class UpdateMaintananceServices
    {
        public string MaintenanceServiceName { get; set; }
        public string Status { get; set; }
        public string? Image { get; set; }
        public bool Boolean { get; set; }
    }
}
