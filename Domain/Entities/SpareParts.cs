using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SpareParts
    {
        public SpareParts()
        {
            SparePartsItems = new HashSet<SparePartsItem>();
        }

        [Key]

        public Guid SparePartId { get; set; }
        public string SparePartName { get; set; }
        public string SparePartDescription { get; set; }
        public string SparePartType { get; set; }
        public DateTime CreatedDate { get; set; }
        public float OriginalPrice { get; set; }
        public string Status { get; set; }
        public Guid VehicleModelId { get; set; }
        public VehicleModel VehicleModel { get; set; }
        public ICollection<SparePartsItem> SparePartsItems { get; set; }
    }
}
