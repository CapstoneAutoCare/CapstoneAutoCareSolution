using Infrastructure.Common.Response.ReponseVehicleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Response.ResponseServicesCare
{
    public class ResponseServicesCare
    {
        public Guid ServiceCareId { get; set; }
        public string ServiceCareName { get; set; }
        public string ServiceCareDescription { get; set; }
        public string ServiceCareType { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Image { get; set; }

        public float OriginalPrice { get; set; }
        public string Status { get; set; }
        public Guid MaintananceScheduleId { get; set; }
        public string MaintananceScheduleName { get; set; }
        public Guid MaintenancePlanId { get; set; }
        public string MaintenancePlanName { get; set; }
        public ReponseVehicleModels ReponseVehicleModel { get; set; }

    }
}
