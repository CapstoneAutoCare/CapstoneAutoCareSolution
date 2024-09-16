using Application.IGenericRepository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IMaintenanceVehiclesDetailRepository : IGenericRepository<MaintenanceVehiclesDetail>
    {
        Task<List<MaintenanceVehiclesDetail>> GetAll();
        Task<List<MaintenanceVehiclesDetail>> GetListByVehicleId(Guid id);
        Task<MaintenanceVehiclesDetail> GetById(Guid? id);
        Task<MaintenanceVehiclesDetail> CheckNotMatch(Guid vehicle, Guid odo, Guid center);
        Task<List<MaintenanceVehiclesDetail>> GetListByPlanAndVehicleAndCenter(Guid plan, Guid vehicle, Guid center);
    }
}
