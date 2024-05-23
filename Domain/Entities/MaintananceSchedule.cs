using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MaintananceSchedule
    {
        public MaintananceSchedule()
        {
            MaintenancePlans = new HashSet<MaintenancePlan>();
            Bookings = new HashSet<Booking>();
        }

        [Key]
        public Guid MaintananceScheduleId { get; set; }
        public string Odo { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid VehicleModelId { get; set; }
        public VehicleModel VehicleModel { get; set; }
        public ICollection<MaintenancePlan> MaintenancePlans { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
