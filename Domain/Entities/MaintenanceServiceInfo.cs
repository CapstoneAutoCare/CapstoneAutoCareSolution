using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MaintenanceServiceInfo
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
        public Guid? MaintenanceServiceId { get; set; }
        public Guid InformationMaintenanceId { get; set; }

        public MaintenanceService MaintenanceService { get; set; }
        public MaintenanceInformation InformationMaintenance { get; set; }

    }
}
