using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Notification
    {
        [Key]
        public Guid NotificationId { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
    }
}
