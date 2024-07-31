using Application.IGenericRepository;
using Domain.Entities;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;
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
        Task<MaintenanceServiceCost> GetById(Guid? id);
        Task<List<MaintenanceServiceCost>> GetListByStatusAndStatusCost(string status, string coststatus, Guid centerId);
        Task<(List<MaintenanceServiceCost> Costs, float TotalCost, int Count)> TotalGetListByStatusAndStatusCost(string status, string coststatus, Guid centerId);

        Task<MaintenanceServiceCost> GetByIdMaintenanceServiceActive(string status, string cost, Guid id);
        Task<List<MaintenanceServiceCost>> GetListByDifMaintenanceServiceAndInforId(string status, string cost, Guid centerId, Guid informationId);


    }
}
