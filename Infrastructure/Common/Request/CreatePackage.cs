using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request
{
    public class CreatePackage
    {
        public string Name { get; set; }
        public int QuantitySparepartAllowUsed { get; set; }
        public int QuantityMaintenanceServiceAllowUsed { get; set; }
        public string Description { get; set; }
        public float MonthlyPrice { get; set; }
        public int DurationMonths { get; set; }
    }
}
