using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MaintenanceTask
    {
        public MaintenanceTask()
        {
            MaintenanceTaskSparePartInfos = new HashSet<MaintenanceTaskSparePartInfo>();
            MaintenanceTaskServiceInfos = new HashSet<MaintenanceTaskServiceInfo>();
        }
        [Key]

        public Guid MaintenanceTaskId { get; set; }
        public string MaintenanceTaskName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
        public Guid InformationMaintenanceId { get; set; }
        public Guid TechnicianId { get; set; }
        public Technician Technician { get; set; }
        public MaintenanceInformation InformationMaintenance { get; set; }
        public ICollection<MaintenanceTaskServiceInfo> MaintenanceTaskServiceInfos { get; set; }
        public ICollection<MaintenanceTaskSparePartInfo> MaintenanceTaskSparePartInfos { get; set; }
    }
}
