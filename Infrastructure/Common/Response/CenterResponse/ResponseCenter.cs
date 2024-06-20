using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Response.ReponseVehicleModel
{
    public class ResponseCenter
    {
        public Guid AccountId { get; set; }
        public Guid MaintenanceCenterId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
        public string Logo { get; set; }
        public string MaintenanceCenterName { get; set; }
        public string MaintenanceCenterDescription { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public float Rating { get; set; }
    }
}
