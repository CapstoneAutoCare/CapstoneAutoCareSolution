using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Account
    {
        public Account()
        {
            Notifications = new List<Notification>();
        }

        [Key]
        public Guid AccountID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Gender { get; set; }

        public string Phone { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
        public string? Logo { get; set; }
        public Client Client { get; set; }
        public MaintenanceCenter MaintenanceCenter { get; set; }
        public CustomerCare CustomerCare { get; set; }
        public Technician Technician { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}
