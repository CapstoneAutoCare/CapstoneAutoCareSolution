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
        public Vehicles()
        {
            Bookings = new HashSet<Booking>();
            OdoHistories = new HashSet<OdoHistory>();
            ImageRepairReceipts = new HashSet<ImageRepairReceipt>();
            MaintenanceVehiclesDetails = new HashSet<MaintenanceVehiclesDetail>();
            Transactions = new HashSet<Transactions>();
        }
        [Key]
        public Guid VehiclesId { get; set; }
        public string Color { get; set; }
        public string LicensePlate { get; set; }
        public int Odo { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
        public Guid VehicleModelId { get; set; }
        public Guid ClientId { get; set; }
        public VehicleModel VehicleModel { get; set; }
        public Client Client { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<OdoHistory> OdoHistories { get; set; }
        public ICollection<ImageRepairReceipt> ImageRepairReceipts { get; set; }
        public ICollection<MaintenanceVehiclesDetail> MaintenanceVehiclesDetails { get; set; }
        public ICollection<Transactions> Transactions { get; set; }

    }
}
