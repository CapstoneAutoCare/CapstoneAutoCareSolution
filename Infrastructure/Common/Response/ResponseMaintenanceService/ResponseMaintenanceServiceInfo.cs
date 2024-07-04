using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Response.ResponseMaintenanceService
{
    public class ResponseMaintenanceServiceInfo
    {
        public Guid MaintenanceServiceInfoId { get; set; }
        public string MaintenanceServiceInfoName { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public double ActualCost { get; set; }
        public double TotalCost { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
        public string Image {  get; set; }
        public Guid? MaintenanceServiceCostId { get; set; }
        public Guid InformationMaintenanceId { get; set; }
    }
}
