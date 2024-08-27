using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Package
    {
        public Package()
        {
            CenterPackages = new HashSet<CenterPackages>();
        }

        public Guid PackageId { get; set; }
        public string Name { get; set; }
        public int QuantitySparepartAllowUsed {  get; set; }
        public int QuantityMaintenanceServiceAllowUsed {  get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public float MonthlyPrice { get; set; }
        public int DurationMonths { get; set; }

        public ICollection<CenterPackages> CenterPackages { get; set; }
    }
}
