using Infrastructure.Common.Request.RequestAccount;
using Infrastructure.Common.Response.ResponseCustomerCare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface ICustomerCareService
    {
        Task<ResponseCustomerCare> CreateCustomerCare(CreateCustomerCare create);
        Task<List<ResponseCustomerCare>> GetAll();
        Task<ResponseCustomerCare> GetCustomerCareById(Guid id);
        Task<List<ResponseCustomerCare>> GetListByCenter(Guid id);
    }
}
