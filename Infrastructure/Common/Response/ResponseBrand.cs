using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Response
{
    public class ResponseBrand
    {
        public Guid VehiclesBrandId { get; set; }
        public string VehiclesBrandName { get; set; }
        public string? VehiclesBrandDescription { get; set; }
        public string? Logo { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
    }
}
