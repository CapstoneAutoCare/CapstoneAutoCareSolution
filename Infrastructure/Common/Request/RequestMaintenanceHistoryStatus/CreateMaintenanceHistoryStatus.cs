using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.RequestMaintenanceHistoryStatus
{
    public class CreateMaintenanceHistoryStatus
    {
        public Guid MaintenanceInformationId { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
    }
}
