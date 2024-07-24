using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MaintenanceServiceCost
    {
        public MaintenanceServiceCost()
        {
            MaintenanceServiceInfos = new HashSet<MaintenanceServiceInfo>();
        }
        [Key]
        public Guid MaintenanceServiceCostId { get; set; }
        public float ActuralCost { get; set; }
        public DateTime DateTime { get; set; }
        public string? Note { get; set; }
        public string Status { get; set; }
        public Guid MaintenanceServiceId { get; set; }
        public MaintenanceService MaintenanceService { get; set; }
        public ICollection<MaintenanceServiceInfo> MaintenanceServiceInfos { get; set; }
    }
}
