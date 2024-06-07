using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Response.ResponseSparePart
{
    public class ResponseSparePartsItem
    {
        public Guid SparePartsItemId { get; set; }
        public string SparepartName { get; set; }

        public double OriginalCost { get; set; }
        public double ActuralCost { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid SparePartsId { get; set; }
        public Guid MaintenanceCenterId { get; set; }
        public string MaintenanceCenterName { get; set; }
    }
}
