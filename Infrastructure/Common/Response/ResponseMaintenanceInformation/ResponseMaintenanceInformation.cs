using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Response.ResponseMaintenanceInformation
{
    public class ResponseMaintenanceInformation
    {
        public Guid InformationMaintenanceId { get; set; }
        public string InformationMaintenanceName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime FinishedDate { get; set; }
        public string Note { get; set; }
        public Guid? BookingId { get; set; }
        public Guid CustomerCareId { get; set; }
    }
}
