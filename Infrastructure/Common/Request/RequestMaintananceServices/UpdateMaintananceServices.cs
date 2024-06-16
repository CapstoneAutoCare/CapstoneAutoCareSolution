using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.MaintananceServices
{
    public class UpdateMaintananceServices
    {
        public double ActuralCost { get; set; }
        public Guid? ServiceCareId { get; set; }
    }
}
