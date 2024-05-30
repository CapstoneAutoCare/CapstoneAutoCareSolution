using Application.IGenericRepository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IMaintenanceHistoryStatusesRepository : IGenericRepository<MaintenanceHistoryStatus>
    {
        Task<List<MaintenanceHistoryStatus>> GetAll();
        Task<MaintenanceHistoryStatus> GetById(Guid id);
        
    }
}
