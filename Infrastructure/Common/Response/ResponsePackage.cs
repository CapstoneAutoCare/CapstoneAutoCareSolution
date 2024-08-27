using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Response
{
    public class ResponsePackage
    {
        public Guid PackageId { get; set; }
        public string Name { get; set; }
        public int QuantitySparepartAllowUsed { get; set; }
        public int QuantityMaintenanceServiceAllowUsed { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public float MonthlyPrice { get; set; }
        public int DurationMonths { get; set; }
    }
}
