using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Common.Response.ResponseHistoryStatus;
using Infrastructure.Common.Response.ResponseMaintenanceService;
using Infrastructure.Common.Response.ResponseMaintenanceSparePart;

namespace Infrastructure.Common.Response.ResponseMaintenanceInformation
{
    public class ResponseMaintenanceInformation
    {
        public Guid InformationMaintenanceId { get; set; }
        public string InformationMaintenanceName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime FinishedDate { get; set; }
        public double TotalPrice { get; set; }
        public string Note { get; set; }
        public Guid? BookingId { get; set; }
        public Guid CustomerCareId { get; set; }
        public List<ResponseMaintenanceServiceInfo> ResponseMaintenanceServiceInfos { get; set; }
        public List<ResponseMaintenanceSparePartInfo> ResponseMaintenanceSparePartInfos { get; set; }
        public List<ResponseMaintenanceHistoryStatus> ResponseMaintenanceHistoryStatuses { get; set; }

    }
}
