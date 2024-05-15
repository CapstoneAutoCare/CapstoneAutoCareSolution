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
        }
        [Key]

        public Guid AccountID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Gender { get; set; }

        public string Phone { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set;}
        public string Logo {  get; set; }
        public Admin Admin { get; set; }
        public Client Client { get; set; }
        public MaintenanceCenter MaintenanceCenter { get; set; }
        public StaffCare StaffCare { get; set; }
    }
}
