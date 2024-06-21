using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Response.OdoResponse
{
    public class ResponseOdoHistory
    {
        public Guid OdoHistoryId { get; set; }
        public string OdoHistoryName { get; set; }
        public int Odo { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public Guid VehiclesId { get; set; }
        public Guid MaintenanceInformationId { get; set; }
    }
}
