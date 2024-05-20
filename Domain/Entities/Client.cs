using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Client
    {
        public Client()
        {
            Bookings = new HashSet<Booking>();
            Vehicles = new HashSet<Vehicles>();
        }

        [Key]

        public Guid ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Vehicles> Vehicles { get; set; }


    }
}
