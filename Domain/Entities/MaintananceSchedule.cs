using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MaintananceSchedule
    {
        public MaintananceSchedule()
        {
            ServiceCares = new HashSet<ServiceCares>();
            MaintenanceVehiclesDetails = new HashSet<MaintenanceVehiclesDetail>();

        }

        [Key]
        public Guid MaintananceScheduleId { get; set; }
        public int MaintananceScheduleName { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public string Status { get; set; }
        public Guid MaintenancePlanId { get; set; }
        public MaintenancePlan MaintenancePlan { get; set; }
        public ICollection<ServiceCares> ServiceCares { get; set; }
        public ICollection<MaintenanceVehiclesDetail> MaintenanceVehiclesDetails { get; set; }
    }
}
