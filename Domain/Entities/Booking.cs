using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Booking
    {
        [Key]

        public Guid BookingId { get; set; }
        public string Note { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime BookingDate { get; set; }
        public string Status { get; set; }
        public Guid ClientId { get; set; }
        public Guid VehicleId { get; set; }
        public Guid MaintenanceCenterId {  get; set; }
        public MaintenanceCenter MaintenanceCenter { get; set; }
        public Vehicles Vehicles { get; set; }
        public Client Client { get; set; }



    }
}
