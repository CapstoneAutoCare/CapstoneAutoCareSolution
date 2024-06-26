﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.RequestMaintenanceTechinican
{
    public class CreateMaintenanceTechinican
    {
        public string MaintenanceTaskName { get; set; }
        public double UnitCost { get; set; }
        public string Status { get; set; }
        public Guid InformationMaintenanceId { get; set; }
        public Guid TechnicianId { get; set; }
    }
}
