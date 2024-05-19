using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class VehiclesMaintenance
    {
        [Key]
        public Guid MaintenanceCenterId { get; set; }
        [Key]
        public Guid VehiclesBrandId { get; set; }
        public VehiclesBrand VehiclesBrand { get; set; }
        public MaintenanceCenter MaintenanceCenter { get; set; }
    }
}
