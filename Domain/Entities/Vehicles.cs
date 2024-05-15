using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Vehicles
    {
        public Vehicles() { }
        [Key]
        public Guid VehiclesId { get; set; }
        public string Color { get; set; }
        public string LicensePlate { get; set; }
        public string Odo { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
        public Guid VehicleModelId { get; set; }
        public Guid ClientId { get; set; }
        public VehicleModel VehicleModel { get; set; }
        public Client Client { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<OdoHistory> OdoHistories { get; set; }
    }
}
