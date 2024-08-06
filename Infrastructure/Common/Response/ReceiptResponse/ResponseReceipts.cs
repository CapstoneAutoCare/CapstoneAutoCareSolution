using Domain.Entities;
using Infrastructure.Common.Response.ResponseMainInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Response.ReceiptResponse
{
    public class ResponseReceipts
    {
        public Guid ReceiptId { get; set; }
        public string ReceiptName { get; set; }
        public float SubTotal { get; set; }
        public int VAT { get; set; }
        public float TotalAmount { get; set; }
        public string status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public Guid MaintenanceCenterId { get; set; }

        public Guid InformationMaintenanceId { get; set; }
        public ResponseMaintenanceInformation ResponseMaintenanceInformation { get; set; }
    }
}
