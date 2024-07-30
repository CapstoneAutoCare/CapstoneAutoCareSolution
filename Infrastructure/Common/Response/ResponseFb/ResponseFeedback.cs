using Domain.Entities;
using Infrastructure.Common.Response.ReceiptResponse;
using Infrastructure.Common.Response.ReponseVehicleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Response.ResponseFb
{
    public class ResponseFeedback
    {
        public Guid FeedBackId { get; set; }
        public string Comment { get; set; }
        public int Vote { get; set; }
        public Guid MaintenanceCenterId { get; set; }
        public Guid ReceiptId { get; set; }
        public ResponseCenter ResponseCenter { get; set; }
        public ResponseReceipts ResponseReceipts { get; set; }
    }
}
