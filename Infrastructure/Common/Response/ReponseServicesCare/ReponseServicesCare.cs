using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Response.ReponseServicesCare
{
    public class ReponseServicesCare
    {
        public Guid ServiceCareId { get; set; }
        public string ServiceCareName { get; set; }
        public string ServiceCareDescription { get; set; }
        public string ServiceCareType { get; set; }
        public DateTime CreatedDate { get; set; }

        public double OriginalPrice { get; set; }
        public string Status { get; set; }
        public Guid MaintenancePlanId { get; set; }
    }
}
