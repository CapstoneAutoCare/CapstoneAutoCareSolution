using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.Sparepart
{
    public class CreateSparePartsItem
    {
        public string SparePartsItemName { get; set; }
        public Guid? SparePartsId { get; set; }
    }
}
