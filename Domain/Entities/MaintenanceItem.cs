using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MaintenanceItem
    {
        [Key]

        public Guid MaintenanceItemId { get; set; }
        public string MaintenanceItemName { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public double ActualCost { get; set; }
        public double TotalCost { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
        public Guid SparePartsCostId { get; set; }
        public Guid ServiceCareCostId { get; set; }
        public Guid InformationMaintenanceId { get; set; }
        public ServiceCareCost ServiceCareCost { get; set; }
        public SparePartsCost SparePartsCost { get; set; }
        public InformationMaintenance InformationMaintenance { get; set; }

    }
}
