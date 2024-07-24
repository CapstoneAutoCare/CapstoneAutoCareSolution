using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MaintenanceSparePartInfo
    {
        public MaintenanceSparePartInfo()
        {
            MaintenanceTaskSparePartInfos = new HashSet<MaintenanceTaskSparePartInfo>();
        }

        [Key]
        public Guid MaintenanceSparePartInfoId { get; set; }
        public string MaintenanceSparePartInfoName { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public float ActualCost { get; set; }
        public float TotalCost { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
        public Guid? SparePartsItemCostId { get; set; }
        public Guid InformationMaintenanceId { get; set; }
        public SparePartsItemCost SparePartsItemCost { get; set; }
        public MaintenanceInformation InformationMaintenance { get; set; }
        public ICollection<MaintenanceTaskSparePartInfo> MaintenanceTaskSparePartInfos { get; set; }
    }
}
