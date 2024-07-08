using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.ReceiptRequest
{
    public class CreateReceipt
    {
        public Guid InformationMaintenanceId { get; set; }
        public string Description { get; set; }

    }
}
