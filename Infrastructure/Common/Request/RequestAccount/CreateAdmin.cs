using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.RequestAccount
{
    public class CreateAdmin
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Logo { get; set; }
    }
}
