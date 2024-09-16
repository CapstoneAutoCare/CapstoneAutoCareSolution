using Infrastructure.Common.Response.ReponseVehicleModel;
using Infrastructure.Common.Response.ResponseMaintenanceSchedule;
using Infrastructure.Common.Response.VehiclesResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Response.ResponseMVD
{
    public class ResponseMaintenanceVehicleDetail
    {
        public Guid MaintenanceVehiclesDetailId { get; set; }

        public DateTime DateTime { get; set; }
        public string Status { get; set; }
        public ResponseVehicles ResponseVehicles { get; set; }
        public ResponseMaintenanceSchedules ResponseMaintenanceSchedules { get; set; }
        public ResponseCenter ResponseCenter { get; set; }
    }
}
