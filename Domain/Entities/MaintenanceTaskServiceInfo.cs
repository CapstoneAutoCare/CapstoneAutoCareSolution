using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MaintenanceTaskServiceInfo
    {
        public MaintenanceTaskServiceInfo()
        {
        }
        [Key]
        public Guid MaintenanceTaskServiceInfoId { get; set; }
        public Guid MaintenanceTaskId { get; set; }
        public Guid MaintenanceServiceInfoId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Status { get; set; }
        public MaintenanceTask MaintenanceTask { get; set; }
        public MaintenanceServiceInfo MaintenanceServiceInfo { get; set; }
    }
}
