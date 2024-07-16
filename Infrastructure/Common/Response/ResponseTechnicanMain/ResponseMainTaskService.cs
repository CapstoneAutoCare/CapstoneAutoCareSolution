using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Response.ResponseTechnicanMain
{
    public class ResponseMainTaskService
    {
        public Guid MaintenanceTaskServiceInfoId { get; set; }
        public Guid MaintenanceTaskId { get; set; }
        public Guid MaintenanceServiceInfoId { get; set; }
        public string Name { get; set; }
        public string Image {  get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Status { get; set; }
    }
}
