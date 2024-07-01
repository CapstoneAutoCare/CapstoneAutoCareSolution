using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.Sparepart
{
    public class UpdateSparePartItem
    {
        public string Status { get; set; }
        public string SparePartsItemName { get; set; }
        public string? Image { get; set; }
        public int Capacity { get; set; }
    }
}
