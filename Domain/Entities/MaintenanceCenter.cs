using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MaintenanceCenter
    {
        [Key]

        public Guid MaintenanceCenterId { get; set; }
        public string MaintenanceCenterName { get; set; }
        public string MaintenanceCenterDescription { get; set; }
        public DateTime CreateDate { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public float Rating { get; set; }
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
        public ICollection<CustomerCare> CustomerCares { get; set; }
        public ICollection<StaffCare> StaffCares { get; set; }

        public ICollection<Booking> Bookings { get; set; }
        public ICollection<SparePartsItem> SparePartsCosts { get; set; }
        public ICollection<MaintenanceService> MaintenanceServices { get; set; }
        public ICollection<FeedBack> FeedBacks { get; set; }
        public ICollection<VehiclesMaintenance> VehiclesMaintenance { get; set; }


    }
}
