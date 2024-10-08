﻿using Infrastructure.Common.Request.RequestMaintenanceInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.RequestBooking
{
    public class RequestBookingHaveItems
    {
        public Guid VehicleId { get; set; }
        public Guid MaintenanceCenterId { get; set; }
        public string Note { get; set; }
        public int? OdoBooking { get; set; }

        public DateTime BookingDate { get; set; }
        public List<CreateMaintenanceInformationHaveItemsByClient> CreateMaintenanceInformationHaveItemsByClient { get; set; }
    }
}
