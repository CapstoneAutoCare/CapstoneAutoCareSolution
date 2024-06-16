using Application.IGenericRepository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IMaintenanceServiceCostRepository : IGenericRepository<MaintenanceServiceCost>
    {
        Task<List<MaintenanceServiceCost>> GetAll();
        Task<MaintenanceServiceCost> GetById(Guid id);
        Task<List<MaintenanceServiceCost>> GetListByStatusAndStatusCost(string status,string coststatus);
    }
}
