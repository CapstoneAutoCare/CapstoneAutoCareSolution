using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Response.ReponseSparePart
{
    public class ResponseSparePart
    {
        public Guid SparePartId { get; set; }
        public string SparePartName { get; set; }
        public string SparePartDescription { get; set; }
        public string SparePartType { get; set; }
        public DateTime CreatedDate { get; set; }
        public double OriginalPrice { get; set; }
        public string Status { get; set; }
        public Guid MaintenancePlanId { get; set; }
        public string MaintenancePlanName { get; set;}

    }
}
