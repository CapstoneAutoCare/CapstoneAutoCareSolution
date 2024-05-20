using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Technician
    {
        public Technician() { }
        [Key]

        public Guid TechnicianId { get; set; }
        public string TechnicialName { get; set; }
        public double UnitCost { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
        public Guid InformationMaintenanceId { get; set; }
        public Guid StaffCareId { get; set; }
        public StaffCare StaffCare { get; set; }
        public MaintenanceInformation InformationMaintenance { get; set; }
    }
}
