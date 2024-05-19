using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Receipt
    {
        [Key]

        public Guid ReceiptId { get; set; }
        public string ReceiptName { get; set; }
        public double SubTotal { get; set; }
        public int VAT { get; set; }
        public double TotalAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public Guid InformationMaintenanceId { get; set; }
        public MaintenanceInformation InformationMaintenance { get; set; }
        public FeedBack FeedBack { get; set; }
    }
}
