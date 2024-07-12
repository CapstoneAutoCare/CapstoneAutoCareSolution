using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MaintenanceTaskSparePartInfo
    {
        public MaintenanceTaskSparePartInfo()
        {
        }
        [Key]

        public Guid MaintenanceTaskSparePartInfoId { get; set; }
        public Guid MaintenanceTaskId { get; set; }
        public Guid MaintenanceSparePartInfoId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Status { get; set; }
        public MaintenanceTask MaintenanceTask { get; set; }
        public MaintenanceSparePartInfo MaintenanceSparePartInfo { get; set; }
    }
}
