using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.RequestMaintenanceInformation
{
    public class CreateMaintenanceInformation
    {
        public string InformationMaintenanceName { get; set; }
        public DateTime FinishedDate { get; set; }
        public string Note { get; set; }
        public Guid? BookingId { get; set; }
    }
}
