using Infrastructure.Common.Response.ReponseVehicleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Response.ResponseSparePart
{
    public class ResponseSparePart
    {
        public Guid SparePartId { get; set; }
        public string SparePartName { get; set; }
        public string SparePartDescription { get; set; }
        public string SparePartType { get; set; }
        public DateTime CreatedDate { get; set; }
        public float OriginalPrice { get; set; }
        public string Status { get; set; }
        public Guid MaintananceScheduleId { get; set; }
        public string MaintananceScheduleName { get; set; }
        public ReponseVehicleModels ReponseVehicleModel { get; set; }


    }
}
