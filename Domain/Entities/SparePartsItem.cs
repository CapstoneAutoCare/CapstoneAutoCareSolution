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
            MaintenanceSparePartInfos = new HashSet<MaintenanceSparePartInfo>();
            SparePartsItemCost = new HashSet<SparePartsItemCost>();
        }

        [Key]

        public Guid SparePartsItemtId { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? SparePartsId { get; set; }
        public Guid MaintenanceCenterId { get; set; }
        public SpareParts SpareParts { get; set; }
        public MaintenanceCenter MaintenanceCenter { get; set; }
        public ICollection<MaintenanceSparePartInfo> MaintenanceSparePartInfos { get; set; }
        public ICollection<SparePartsItemCost> SparePartsItemCost { get; set; }
    }
}
