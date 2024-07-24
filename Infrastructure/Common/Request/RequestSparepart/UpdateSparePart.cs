using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.Sparepart
{
    public class UpdateSparePart
    {
        public string SparePartName { get; set; }
        public string SparePartDescription { get; set; }
        public string SparePartType { get; set; }
        public float OriginalPrice { get; set; }
    }
}
