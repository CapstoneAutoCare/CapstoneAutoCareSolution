using Application.IGenericRepository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IMaintenancePlanRepository : IGenericRepository<MaintenancePlan>
    {
        Task<List<MaintenancePlan>> GetAll();
        Task<MaintenancePlan> GetById(Guid id);
        Task<List<MaintenancePlan>> GetListCenterId(Guid id);
        Task<List<MaintenancePlan>> GetListCenterIdAndVehicle(Guid id,Guid vehicleId);

    }
}
