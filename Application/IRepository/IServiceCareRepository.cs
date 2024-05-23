using Application.IGenericRepository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IServiceCareRepository: IGenericRepository<ServiceCare>
    {
        Task<List<ServiceCare>> GetAll();
        Task<ServiceCare> GetByID(Guid id);
    }
}
