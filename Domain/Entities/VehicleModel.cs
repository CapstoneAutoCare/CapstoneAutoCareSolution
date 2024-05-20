using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class VehicleModel
    {
        public VehicleModel()
        {
            Vehicles = new HashSet<Vehicles>();
            MaintenanceSchedules = new HashSet<MaintananceSchedule>();
        }

        [Key]
        public Guid VehicleModelId { get; set; }
        public string VehicleModelName { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid VehiclesBrandId { get; set; }
        public VehiclesBrand VehiclesBrand { get; set; }
        public ICollection<Vehicles> Vehicles { get; set; }
        public ICollection<MaintananceSchedule> MaintenanceSchedules { get; set; }
    }
}
