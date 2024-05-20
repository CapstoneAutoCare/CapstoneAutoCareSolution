using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MaintenanceHistoryStatus
    {
        public MaintenanceHistoryStatus()
        {

        }
        [Key]
        public Guid MaintenanceHistoryStatusId { get; set; }
        public string Status { get; set; }
        public DateTime DateTime { get; set; }
        public string Note { get; set; }
        public Guid MaintenanceInformationId { get; set; }
        public MaintenanceInformation MaintenanceInformation { get; set; }
    }
}
