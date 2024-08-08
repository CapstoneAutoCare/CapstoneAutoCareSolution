using Application.IGenericRepository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IServiceCareRepository: IGenericRepository<ServiceCares>
    {
        Task<List<ServiceCares>> GetAll();
        Task<ServiceCares> GetByID(Guid? id);
        Task<List<ServiceCares>> GetServiceCaresNotInMaintenanceServices(Guid centerId);
    }
}
