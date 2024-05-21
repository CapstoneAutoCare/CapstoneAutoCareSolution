﻿using Domain.Entities;
using Infrastructure.Common.Request.RequestAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface ICustomerService
    {
        Task<Client> CreateCustomer(CreateClient client);
    }
}