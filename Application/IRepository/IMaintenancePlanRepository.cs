using Application.IGenericRepository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IMaintenancePlanRepository: IGenericRepository<MaintenancePlan>
    {
        Task<List<MaintenancePlan>> GetAll();
        Task<MaintenancePlan> GetByID(Guid id);
    }
}
