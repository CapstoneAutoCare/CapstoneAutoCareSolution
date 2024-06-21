using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.RequestOdo
{
    public class CreateOdoHistory
    {
        public int Odo { get; set; }
        public string Description { get; set; }
        public Guid VehiclesId { get; set; }
        public Guid MaintenanceInformationId { get; set; }
    }
}
