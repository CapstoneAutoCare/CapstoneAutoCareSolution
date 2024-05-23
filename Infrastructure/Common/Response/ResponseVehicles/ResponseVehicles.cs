using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Response.ResponseVehicles
{
    public class ResponseVehicles
    {
        public Guid VehiclesId { get; set; }
        public Guid VehicleModelId { get; set; }
        public Guid ClientId { get; set; }
        public Guid VehiclesBrandId { get; set; }
        public string VehiclesBrandName { get; set; }
        public string VehicleModelName { get; set; }
        public string Color { get; set; }
        public string LicensePlate { get; set; }
        public string Odo { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }

    }
}
