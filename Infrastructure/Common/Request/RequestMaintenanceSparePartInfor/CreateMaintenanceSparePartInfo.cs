using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.RequestMaintenanceSparePartInfor
{
    public class CreateMaintenanceSparePartInfo
    {
        public Guid MaintenanceInformationId { get; set; }
        public Guid? SparePartsItemCostId { get; set; }
        public string MaintenanceSparePartInfoName { get; set; }
        public int Quantity { get; set; }
        public double ActualCost { get; set; }
        public string Note { get; set; }

    }
}
