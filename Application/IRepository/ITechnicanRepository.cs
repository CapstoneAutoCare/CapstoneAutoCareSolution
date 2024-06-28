using Application.IGenericRepository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IMaintenanceTaskRepository : IGenericRepository<MaintenanceTask>
    {
        Task<MaintenanceTask> GetById(Guid id);
        Task<List<MaintenanceTask>> GetAll();
    }
}
