using Infrastructure.Common.Response.ResponseMainInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Response.ResponseBooking
{
    public class ResponseBooking
    {
        public Guid BookingId { get; set; }
        public string Note { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime BookingDate { get; set; }
        public string Status { get; set; }
        public Guid ClientId { get; set; }
        public Guid VehicleId { get; set; }
        public Guid MaintenanceCenterId { get; set; }
        public ResponseMaintenanceInformation ResponseMaintenanceInformation { get; set; }
    }
}
