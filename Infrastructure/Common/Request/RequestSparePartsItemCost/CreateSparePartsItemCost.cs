using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.RequestSparePartsItemCost
{
    public class CreateSparePartsItemCost
    {
        public float ActuralCost { get; set; }
        public string? Note { get; set; }
        public Guid SparePartsItemId { get; set; }
    }
}
