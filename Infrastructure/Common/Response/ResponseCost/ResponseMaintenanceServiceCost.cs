﻿using Infrastructure.Common.Response.ResponseServicesCare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Response.ResponseCost
{
    public class ResponseMaintenanceServiceCost
    {
        public Guid MaintenanceServiceCostId { get; set; }
        public double ActuralCost { get; set; }
        public DateTime DateTime { get; set; }
        public string? Note { get; set; }
        public string Status { get; set; }
        public Guid MaintenanceServiceId { get; set; }
        public string MaintenanceServiceName { get; set; }

    }
}
