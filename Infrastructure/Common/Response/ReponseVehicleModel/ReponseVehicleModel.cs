using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Response.ReponseVehicleModel
{
    public class ReponseVehicleModel
    {
        public string VehicleModelName { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }
        public string CreatedDate { get; set; }
        public string VehiclesBrand { get; set; }
    }
}
