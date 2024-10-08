﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.RequestBooking
{
    public class CreateBookingPackage
    {
        public Guid VehicleId { get; set; }
        public Guid MaintenanceCenterId { get; set; }
        public Guid? MaintananceScheduleId { get; set; }
        public string Note { get; set; }
        public int? OdoBooking { get; set; }

        public DateTime BookingDate { get; set; }
        public string InformationName {  get; set; }
    }
}
