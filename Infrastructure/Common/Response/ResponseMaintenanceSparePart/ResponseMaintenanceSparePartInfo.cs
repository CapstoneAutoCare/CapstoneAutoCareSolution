using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Response.ResponseMaintenanceSparePart
{
    public class ResponseMaintenanceSparePartInfo
    {
        public Guid MaintenanceSparePartInfoId { get; set; }
        public string MaintenanceSparePartInfoName { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public double ActualCost { get; set; }
        public double TotalCost { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
        public Guid? SparePartsCostId { get; set; }
        public Guid InformationMaintenanceId { get; set; }
    }
}
