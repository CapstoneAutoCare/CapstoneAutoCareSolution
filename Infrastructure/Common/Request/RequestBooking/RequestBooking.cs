using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.RequestBooking
{
    public class RequestBooking
    {
        public Guid VehicleId { get; set; }
        public Guid MaintenanceCenterId { get; set; }
        public Guid? MaintananceScheduleId { get; set; }
        public string Note { get; set; }
        public DateTime BookingDate { get; set; }


    }
}
