using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class VehiclesBrand
    {
        [Key]
        public Guid VehiclesBrandId {  get; set; }
        public string VehiclesBrandName { get; set; }
        public DateTime CreatedDate { get; set;}
        public string Status { get; set;}
        public ICollection<VehicleModel> VehicleModels { get; set; }
    }
}
