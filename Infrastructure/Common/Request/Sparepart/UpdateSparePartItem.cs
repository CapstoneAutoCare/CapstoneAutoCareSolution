using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.Sparepart
{
    public class UpdateSparePartItem
    {
        public double ActuralCost { get; set; }
        public Guid? SparePartsId { get; set; }
        public Guid MaintenanceCenterId { get; set; }
    }
}
