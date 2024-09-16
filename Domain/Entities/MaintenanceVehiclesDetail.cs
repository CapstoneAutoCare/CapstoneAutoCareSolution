using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MaintenanceVehiclesDetail
    {
        public MaintenanceVehiclesDetail()
        {
            MaintenanceInformations = new HashSet<MaintenanceInformation>();
        }
        [Key]
        public Guid MaintenanceVehiclesDetailId { get; set; }

        public Guid MaintananceScheduleId { get; set; }
        public Guid VehiclesId { get; set; }
        public Guid MaintenanceCenterId { get; set; }

        public DateTime DateTime { get; set; }
        public string Status { get; set; }
        public MaintananceSchedule MaintananceSchedule { get; set; }
        public MaintenanceCenter MaintenanceCenter { get; set; }
        public Vehicles Vehicle { get; set; }
        public ICollection<MaintenanceInformation> MaintenanceInformations { get; set; }
    }
}
