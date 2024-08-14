using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.RequestVehicleBrandRequest
{
    public class CreateBrand
    {
        public string VehiclesBrandName { get; set; }
        public string VehiclesBrandDescription { get; set; }
        public string Logo { get; set; }
    }
}
