﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Common.Response.ResponseHistoryStatus;
using Infrastructure.Common.Response.ResponseMaintenanceService;
using Infrastructure.Common.Response.ResponseMaintenanceSparePart;
using Infrastructure.Common.Response.VehiclesResponse;

namespace Infrastructure.Common.Response.ResponseMainInformation
{
    public class ResponseMaintenanceInformation
    {
        public Guid InformationMaintenanceId { get; set; }
        public string InformationMaintenanceName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DateBooking { get; set; }
        public DateTime FinishedDate { get; set; }
        public float TotalPrice { get; set; }
        public string Note { get; set; }
        public Guid? BookingId { get; set; }
        public Guid CustomerCareId { get; set; }
        public string Status {  get; set; }

        public List<ResponseMaintenanceServiceInfo> ResponseMaintenanceServiceInfos { get; set; }
        public List<ResponseMaintenanceSparePartInfo> ResponseMaintenanceSparePartInfos { get; set; }
        public List<ResponseMaintenanceHistoryStatus> ResponseMaintenanceHistoryStatuses { get; set; }
        public ResponseVehicles ResponseVehicles { get; set; }
        
    }
}
