using Domain.Entities;
using Infrastructure.Common.Response.ReponseVehicleModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Response
{
    public class ResponseVehiclesMaintenance
    {
        //public Guid MaintenanceCenterId { get; set; }
        //public Guid VehiclesBrandId { get; set; }
        public ResponseBrand ResponseBrand { get; set; }
        public ResponseCenter ResponseCenter { get; set; }  
    }
}
