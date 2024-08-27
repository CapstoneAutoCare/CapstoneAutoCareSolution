using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Response
{
    public class ResponseCenterPackage
    {
        public Guid CenterPackagesId { get; set; }
        public Guid PackageId { get; set; }
        public Guid MaintenanceCenterId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
    }
}
