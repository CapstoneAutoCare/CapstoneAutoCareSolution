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
        public MaintenanceService()
        {
            MaintenanceServiceCosts = new HashSet<MaintenanceServiceCost>();
        }
        [Key]
        public Guid MaintenanceServiceId { get; set; }
        public string MaintenanceServiceName { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Image { get; set; }
        public Guid? ServiceCareId { get; set; }
        public Guid MaintenanceCenterId { get; set; }
        public ServiceCares ServiceCare { get; set; }
        public MaintenanceCenter MaintenanceCenter { get; set; }
        public ICollection<MaintenanceServiceCost> MaintenanceServiceCosts { get; set; }

    }
}
