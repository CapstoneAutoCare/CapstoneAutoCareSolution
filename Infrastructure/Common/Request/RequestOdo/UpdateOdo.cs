using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.RequestOdo
{
    public class UpdateOdo
    {
        public string OdoHistoryName { get; set; }
        public int Odo { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
