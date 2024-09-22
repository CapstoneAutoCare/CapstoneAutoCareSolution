using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.RequestMaintenanceInformation
{
    public class CreateMainV1
    {
        public string Note { get; set; }
        public Guid BookingId { get; set; }
        public Guid CustomerCareId { get; set; }
        public Guid InformationMaintenanceId { get; set; }
    }
}
