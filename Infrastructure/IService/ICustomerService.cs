using Domain.Entities;
using Infrastructure.Common.Request.RequestAccount;
using Infrastructure.Common.Response.ClientResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface ICustomerService
    {
        Task<ResponseClient> CreateCustomer(CreateClient client);
        Task<ResponseClient> GetById(Guid id);
        Task<List<ResponseClient>> GetAll();
    }
}
