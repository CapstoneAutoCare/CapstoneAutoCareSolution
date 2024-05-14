using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class InformationMaintenance
    {
        [Key]

        public Guid InformationMaintenanceId { get; set; }
        public string InformationMaintenanceName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime FinishedDate { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
        public Guid StaffCareId { get; set; }
        public StaffCare StaffCare { get; set; }
        public ICollection<MaintenanceItem> MaintenanceItems { get; set; }
        public ICollection<TechnicianCost> TechnicianCost { get; set; }
        public ICollection<ServiceItem> ServiceItems { get; set; }
        public Receipt Receipt { get; set; }

    }
}
