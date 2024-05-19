using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OdoHistory
    {
        [Key]

        public Guid OdoHistoryId { get; set; }
        public string OdoHistoryName { get; set; }
        public string Odo { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public Guid VehiclesId { get; set; }
        public Guid MaintenanceInformationId { get; set; }
        public Vehicles Vehicles { get; set; }
        public MaintenanceInformation MaintenanceInformation { get; set; }
    }
}
