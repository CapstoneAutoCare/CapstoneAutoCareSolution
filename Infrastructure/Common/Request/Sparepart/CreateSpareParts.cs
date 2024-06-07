using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.Sparepart
{
    public class CreateSpareParts
    {
        public string SparePartName { get; set; }
        public string SparePartDescription { get; set; }
        public string SparePartType { get; set; }
        public double OriginalPrice { get; set; }
        public Guid MaintananceScheduleId { get; set; }
    }
}
