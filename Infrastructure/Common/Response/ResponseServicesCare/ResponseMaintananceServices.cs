﻿using Infrastructure.Common.Response.ResponseCost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Response.ResponseServicesCare
{
    public class ResponseMaintananceServices
    {
        public Guid MaintenanceServiceId { get; set; }
        public string MaintenanceServiceName { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Image { get; set; }
        public bool Boolean {  get; set; }
        public Guid ServiceCareId { get; set; }
        public Guid MaintenanceCenterId { get; set; }
        public string MaintenanceCenterName { get; set; }
        public List<ResponseMaintenanceServiceCost> ResponseMaintenanceServiceCosts { get; set; }
        public string VehiclesBrandName { get; set; }
        public string VehicleModelName { get; set; }
        public string MaintananceScheduleName { get; set; }
        public Guid MaintananceScheduleId { get; set; }


    }
}
