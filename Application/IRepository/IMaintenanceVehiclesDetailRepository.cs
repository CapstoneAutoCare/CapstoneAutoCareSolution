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
        Task<List<MaintenanceVehiclesDetail>> GetListByCenterId(Guid centerId);
        Task<MaintenanceVehiclesDetail> GetById(Guid? id);
        Task<MaintenanceVehiclesDetail> CheckNotMatch(Guid vehicle, Guid odo, Guid center);
        Task<List<MaintenanceVehiclesDetail>> GetListByPlanAndVehicleAndCenter(Guid plan, Guid vehicle, Guid center);
        Task<List<MaintenanceVehiclesDetail>> GetListByPlanAndVehicleAndCenterStatusPending(Guid plan, Guid vehicle, Guid center);
        Task<MaintenanceVehiclesDetail> GetListByPlanAndVehicleAndCenterWithStatusFinished(Guid plan, Guid vehicle, Guid center);
        //Task<List<MaintenanceVehiclesDetail>> GetListFinishedByPlanAndVehicleAndCenter(Guid plan, Guid vehicle, Guid center);
    }
}
