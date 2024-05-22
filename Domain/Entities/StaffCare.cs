using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class StaffCare
    {
        public StaffCare()
        {
            InformationMaintenances = new HashSet<MaintenanceInformation>();
            Technicians = new HashSet<Technician>();
        }

        public Guid StaffCareId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public string StaffCareDescription { get; set; }

        public Guid AccountId { get; set; }
        public Guid CenterId { get; set; }
        public MaintenanceCenter MaintenanceCenter { get; set; }
        public Account Account { get; set; }
        public ICollection<MaintenanceInformation> InformationMaintenances { get; set; }
        public ICollection<Technician> Technicians { get; set; }
    }
}
