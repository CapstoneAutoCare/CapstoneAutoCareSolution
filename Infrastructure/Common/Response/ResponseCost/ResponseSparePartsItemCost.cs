using Infrastructure.Common.Response.ResponseSparePart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Response.ResponseCost
{
    public class ResponseSparePartsItemCost
    {
        public Guid SparePartsItemCostId { get; set; }
        public double ActuralCost { get; set; }
        public DateTime DateTime { get; set; }
        public string? Note { get; set; }
        public string Status { get; set; }
        public Guid SparePartsItemId { get; set; }
        public string Image {  get; set; }
        public string SparePartsItemName { get; set; }


    }
}
