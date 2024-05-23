﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.MaintenanceSchedule
{
    public class CreateMaintenanceSchedule
    {
        public string Odo { get; set; }
        public string Description { get; set; }
        public Guid VehicleModelId { get; set; }
    }
}
