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
        public VehiclesBrand()
        {
            VehicleModels = new HashSet<VehicleModel>();
            VehiclesMaintenance = new HashSet<VehiclesMaintenance>();
        }

        [Key]
        public Guid VehiclesBrandId {  get; set; }
        public string VehiclesBrandName { get; set; }
        public DateTime CreatedDate { get; set;}
        public string Status { get; set;}
        public ICollection<VehicleModel> VehicleModels { get; set; }
        public ICollection<VehiclesMaintenance> VehiclesMaintenance { get; set;}
    }
}
