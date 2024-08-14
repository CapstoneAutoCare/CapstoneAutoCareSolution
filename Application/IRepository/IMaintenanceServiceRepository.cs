using Application.IGenericRepository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IMaintenanceServiceRepository : IGenericRepository<MaintenanceService>
    {
        Task<List<MaintenanceService>> GetAll();
        Task<MaintenanceService> GetById(Guid? id);
        Task<List<MaintenanceService>> GetListByCenter(Guid center);
        Task<MaintenanceService> CheckServiceAdminExistWithCenterId(Guid? serviceadmin, Guid centerId);
        Task<List<MaintenanceService>> GetListPackageByOdoAndCenterId(Guid centerId, Guid odoId);
        Task<List<MaintenanceService>> GetListPackageByOdoAndCenterIdAndVehicleId(Guid centerId, Guid? odoId, Guid modelvehicleId);
        Task<List<MaintenanceService>> GetListPackageOdoTRUEByCenterId(Guid centerId);
        Task<List<MaintenanceService>> GetListPackageOdoTRUEByCenterIdAndModelId(Guid centerId, Guid modelId);
        Task<List<MaintenanceService>> GetListMainSerivceByServiceId(Guid id);

    }
}
