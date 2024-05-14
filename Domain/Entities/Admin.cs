using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Admin
    {
        public Admin()
        {
        }
        [Key]
        public Guid AdminId { get; set; }
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
    }
}
