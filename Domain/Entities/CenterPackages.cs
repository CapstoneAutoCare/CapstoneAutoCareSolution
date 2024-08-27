using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CenterPackages
    {
        public CenterPackages()
        {
        }

        public Guid CenterPackagesId { get; set; }
        public Guid PackageId { get; set; }
        public Guid MaintenanceCenterId { get;set; }
        public DateTime StartDate {  get; set; }
        public DateTime EndDate { get; set; }
        public string Status {  get; set; }

        public MaintenanceCenter MaintenanceCenter { get; set; }
        public Package Package { get; set; }
        public Transactions Transactions { get; set; }
    }
}
