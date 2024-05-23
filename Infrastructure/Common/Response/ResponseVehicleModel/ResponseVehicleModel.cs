using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Response.ReponseVehicleModel
{
    public class ResponseVehicleModel
    {
        public Guid VehicleModelId { get; set; }
        public Guid VehiclesBrandId { get; set; }
        public string VehiclesBrandName { get; set; }
        public string VehicleModelName { get; set; }
        public string Image { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }


    }
}
