using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.VMRequest
{
    public class CreateVehicleMain
    {
        public Guid MaintenanceCenterId { get; set; }
        public List<Guid> VehiclesBrandIds { get; set; }
    }
}
