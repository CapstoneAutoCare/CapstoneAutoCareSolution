using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SparePartsItem
    {
        public SparePartsItem()
        {
            SparePartsItemCost = new HashSet<SparePartsItemCost>();
        }

        [Key]

        public Guid SparePartsItemId { get; set; }
        public string Status { get; set; }
        public string SparePartsItemName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Image { get; set; }
        public int? Capacity { get; set; }
        public Guid? SparePartsId { get; set; }
        public Guid MaintenanceCenterId { get; set; }
        public SpareParts SpareParts { get; set; }
        public MaintenanceCenter MaintenanceCenter { get; set; }
        public ICollection<SparePartsItemCost> SparePartsItemCost { get; set; }
    }
}
