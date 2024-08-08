    using Application.IGenericRepository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface ICustomerCareRepository : IGenericRepository<CustomerCare>
    {
        Task<CustomerCare> GetById(Guid? id);
        Task<List<CustomerCare>> GetAll();
        Task<List<CustomerCare>> GetListByCenter(Guid id);
    }
}
