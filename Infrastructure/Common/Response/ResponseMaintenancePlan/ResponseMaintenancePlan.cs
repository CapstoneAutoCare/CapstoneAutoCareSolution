﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Response.ResponseMaintenancePlan
{
    public class ResponseMaintenancePlan
    {
        public Guid MaintenancePlanId { get; set; }
        public int MaintenancePlanName { get; set; }
        public string MaintenancePlanDescription { get; set; }
        public DateTime CreateDate { get; set; }
        public string Status { get; set; }
        public Guid MaintananceScheduleId { get; set; }
    }
}
