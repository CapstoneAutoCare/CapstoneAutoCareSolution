using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Response.ReponseMaintenanceSchedule
{
    public class ReponseMaintenanceSchedule
    {
        public Guid MaintananceScheduleId { get; set; }
        public string Odo { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid VehicleModelId { get; set; }
        public string VihecleModelName {  get; set; }
    }
}
