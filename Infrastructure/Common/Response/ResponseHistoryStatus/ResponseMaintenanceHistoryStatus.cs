using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Response.ResponseHistoryStatus
{
    public class ResponseMaintenanceHistoryStatus
    {
        public Guid MaintenanceHistoryStatusId { get; set; }
        public string Status { get; set; }
        public DateTime DateTime { get; set; }
        public string Note { get; set; }
        public Guid MaintenanceInformationId { get; set; }
    }
}
