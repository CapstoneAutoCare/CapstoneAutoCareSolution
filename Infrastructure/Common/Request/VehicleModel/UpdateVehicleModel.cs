using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.VehicleModel
{
    public class UpdateVehicleModel
    {
        public string VehicleModelName { get; set; }
        public string Image { get; set; }
        public Guid VehiclesBrandId { get; set; }
    }
}

