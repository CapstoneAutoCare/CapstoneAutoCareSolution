using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.RequestFb
{
    public class CreateFeedBack
    {
        public string Comment { get; set; }
        public int Vote { get; set; }
        public Guid MaintenanceCenterId { get; set; }
        public Guid ReceiptId { get; set; }
    }
}
