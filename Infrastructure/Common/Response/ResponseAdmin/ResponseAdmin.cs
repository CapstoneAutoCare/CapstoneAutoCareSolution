using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Response.ResponseAdmin
{
    public class ResponseAdmin
    {
        public Guid AccountId { get; set; }
        public Guid AdminId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
        public string Logo { get; set; }
    }
}
