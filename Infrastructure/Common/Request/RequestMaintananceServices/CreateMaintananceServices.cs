using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.MaintananceServices
{
    public class CreateMaintananceServices
    {
        public string MaintenanceServiceName { get; set; }
        public Guid VehicleModelId { get; set; }
        public Guid? ServiceCareId { get; set; }
    }
}
