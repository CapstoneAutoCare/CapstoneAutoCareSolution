using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FeedBack
    {
        public FeedBack()
        {
        }

        [Key]
        public Guid FeedBackId { get; set; }
        public string Comment { get; set; }
        public int Vote { get; set; }
        public Guid MaintenanceCenterId { get; set; }
        public Guid ReceiptId { get; set; }
        public MaintenanceCenter MaintenanceCenter { get; set; }
        public Receipt Receipt { get; set; }
    }
}
