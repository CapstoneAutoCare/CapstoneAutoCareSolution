using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Response.ResponseTechnicanMain
{
    public class ResponseMainTaskSparePart
    {
        public Guid MaintenanceTaskSparePartInfoId { get; set; }
        public Guid MaintenanceTaskId { get; set; }
        public Guid MaintenanceSparePartInfoId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Status { get; set; }
    }
}
