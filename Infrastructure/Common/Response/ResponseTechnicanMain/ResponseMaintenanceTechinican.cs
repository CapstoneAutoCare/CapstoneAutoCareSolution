using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Response.ResponseTechnicanMain
{
    public class ResponseMaintenanceTechinican
    {
        public Guid TechnicianId { get; set; }
        public string TechnicialName { get; set; }
        public double UnitCost { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
        public Guid InformationMaintenanceId { get; set; }
        public Guid StaffCareId { get; set; }
    }
}
