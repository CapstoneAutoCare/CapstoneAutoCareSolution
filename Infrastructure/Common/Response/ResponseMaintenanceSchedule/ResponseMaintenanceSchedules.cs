using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Response.ResponseMaintenanceSchedule
{
    public class ResponseMaintenanceSchedules
    {
        public Guid MaintananceScheduleId { get; set; }
        public int MaintananceScheduleName { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid VehicleModelId { get; set; }
        public Guid VehiclesBrandId { get; set; }
        public string VehiclesBrandName { get; set; }
        public string VehicleModelName { get; set; }
    }
}
