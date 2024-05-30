using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.RequestMaintenanceServiceInfo
{
    public class CreateMaintenanceServiceInfoHaveItems
    {
        public Guid? MaintenanceServiceId { get; set; }
        public string MaintenanceServiceInfoName { get; set; }
        public int Quantity { get; set; }
        public double ActualCost { get; set; }
        public string Note { get; set; }
    }
}
