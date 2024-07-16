using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MaintenanceInformation
    {
        public MaintenanceInformation()
        {
            MaintenanceHistoryStatuses = new HashSet<MaintenanceHistoryStatus>();
            MaintenanceSparePartInfos = new HashSet<MaintenanceSparePartInfo>();
            MaintenanceServiceInfos = new HashSet<MaintenanceServiceInfo>();
            MaintenanceTasks = new HashSet<MaintenanceTask>();
        }

        [Key]
        public Guid InformationMaintenanceId { get; set; }
        public string InformationMaintenanceName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime FinishedDate { get; set; }
        public double TotalPrice { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public Guid? BookingId { get; set; }
        public Guid CustomerCareId { get; set; }
        public Booking Booking { get; set; }
        public CustomerCare CustomerCare { get; set; }
        public ICollection<MaintenanceSparePartInfo> MaintenanceSparePartInfos { get; set; }
        public ICollection<MaintenanceServiceInfo> MaintenanceServiceInfos { get; set; }
        public ICollection<MaintenanceTask> MaintenanceTasks { get; set; }
        public ICollection<MaintenanceHistoryStatus> MaintenanceHistoryStatuses { get; set; }

        public Receipt Receipt { get; set; }
        public OdoHistory OdoHistory { get; set; }

    }
}
