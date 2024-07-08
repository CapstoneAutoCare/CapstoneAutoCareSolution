using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Request.RequestAccount
{
    public class UpdateCenter
    {
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Logo { get; set; }

        public string MaintenanceCenterName { get; set; }
        public string MaintenanceCenterDescription { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
