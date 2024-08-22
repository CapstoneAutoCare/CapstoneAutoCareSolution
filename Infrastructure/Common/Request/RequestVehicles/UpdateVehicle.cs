using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.RequestVehicles
{
    public class UpdateVehicle
    {
        public string Color { get; set; }
        public string LicensePlate { get; set; }
        public int Odo { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

    }
}
