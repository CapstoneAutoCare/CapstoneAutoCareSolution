using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CustomerCare
    {
        public CustomerCare()
        {
            InformationMaintenances = new HashSet<MaintenanceInformation>();
        }

        [Key]
        public Guid CustomerCareId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public string CustomerCareDescription { get; set; }

        public Guid AccountId { get; set; }
        public Guid CenterId { get; set; }
        public MaintenanceCenter MaintenanceCenter { get; set; }
        public Account Account { get; set; }
        public ICollection<MaintenanceInformation> InformationMaintenances { get; set; }
    }
}
