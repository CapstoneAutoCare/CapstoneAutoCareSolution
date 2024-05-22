﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.VehicleModel
{
    public class CreateVehicleModel
    {
        public string VehicleModelName { get; set; }
        public string Image { get; set; }
        public int VehiclesBrandId { get; set; }
    }
}
