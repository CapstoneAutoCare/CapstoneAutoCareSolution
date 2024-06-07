using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MaintenancePlan
    {
        public MaintenancePlan()
        {
            Parts = new HashSet<SpareParts>();
            ServiceCares = new HashSet<ServiceCare>();
        }
        [Key]

        public Guid MaintenancePlanId { get; set; }
        public int MaintenancePlanName { get; set; }
        public string MaintenancePlanDescription { get; set; }
        public DateTime CreateDate { get; set; }
        public string Status { get; set; }
        public Guid MaintananceScheduleId { get; set; }
        public MaintananceSchedule MaintananceSchedule { get; set; }
        public ICollection<SpareParts> Parts { get; set; }
        public ICollection<ServiceCare> ServiceCares { get; set; }

    }
}
