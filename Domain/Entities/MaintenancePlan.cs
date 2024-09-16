using System;
using System.Collections;
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
            MaintenanceSchedules = new HashSet<MaintananceSchedule>();
            Bookings = new HashSet<Booking>();
            Transactions=new HashSet<Transactions>();
        }

        [Key]
        public Guid MaintenancePlanId { get; set; }
        public string MaintenancePlanName { get; set; }
        public string Description { get; set; }

        public string Status { get; set; }
        public DateTime DateTime { get; set; }
        public Guid VehicleModelId { get; set; }
        public VehicleModel VehicleModel { get; set; }
        public ICollection<MaintananceSchedule> MaintenanceSchedules { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Transactions> Transactions { get; set; }

    }
}
