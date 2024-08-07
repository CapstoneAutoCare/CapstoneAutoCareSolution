﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Response.ResponseCustomerCare
{
    public class ResponseCustomerCare
    {
        public Guid CustomerCareId { get; set; }
        public Guid AccountId { get; set; }
        public Guid CentreId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Logo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public string CustomerCareDescription { get; set; }
        public string Status { get; set; }


    }
}
