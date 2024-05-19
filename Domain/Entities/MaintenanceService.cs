using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MaintenanceService
    {
        [Key]
        public Guid MaintenanceServiceId { get; set; }
        public double ActuralCost { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid ServiceCareId { get; set; }
        public Guid MaintenanceCenterId { get; set; }
        public ServiceCare ServiceCare { get; set; }
        public MaintenanceCenter MaintenanceCenter { get; set; }
        public ICollection<MaintenanceItem> MaintenanceItems { get; set; }

    }
}
