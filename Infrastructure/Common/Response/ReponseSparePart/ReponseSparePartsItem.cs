using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Response.ReponseSparePart
{
    public class ReponseSparePartsItem
    {
        public Guid SparePartsItemtId { get; set; }
        public double OriginalCost {  get; set; }
        public double ActuralCost { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid SparePartsId { get; set; }
        public Guid MaintenanceCenterId { get; set; }
    }
}
