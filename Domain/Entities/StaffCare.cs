using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class StaffCare
    {
        public StaffCare() { }
        [Key]
        public Guid StaffCareId { get; set; }
        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public string StaffCareDescription { get; set; }

        public Guid AccountId { get; set; }
        public Guid CenterId { get; set; }
        public MaintenanceCenter MaintenanceCenter { get; set; }
        public Account Account { get; set; }
        public ICollection<InformationMaintenance> InformationMaintenances { get; set; }
    }
}
