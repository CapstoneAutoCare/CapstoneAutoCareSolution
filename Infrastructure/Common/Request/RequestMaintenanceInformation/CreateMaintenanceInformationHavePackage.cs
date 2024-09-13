using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.RequestMaintenanceInformation
{
    public class CreateMaintenanceInformationHavePackage
    {
        public string InformationMaintenanceName { get; set; }
        public string Note { get; set; }
        public Guid? BookingId { get; set; }
        public Guid? CustomerCareId { get; set; }
        public Guid? MaintananceScheduleId { get; set; }
    }
}
