using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.RequestMainVehicleDetail
{
    public class CreateMainVehicleDetail
    {
        public Guid MaintanancePlanId { get; set; }
        public Guid VehiclesId { get; set; }
        public Guid MaintenanceCenterId { get; set; }

    }
}
