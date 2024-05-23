using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.RequestVehicles
{
    public class CreateVehicle
    {
        public Guid VehicleModelId { get; set; }
        public string Color { get; set; }
        public string LicensePlate { get; set; }
        public string Odo { get; set; }
        public string Description { get; set; }
    }
}
