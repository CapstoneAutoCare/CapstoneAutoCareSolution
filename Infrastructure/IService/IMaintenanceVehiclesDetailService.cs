using Infrastructure.Common.Request.MaintenancePlan;
using Infrastructure.Common.Request.RequestMainVehicleDetail;
using Infrastructure.Common.Response.ResponseMaintenancePlan;
using Infrastructure.Common.Response.ResponseMVD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface IMaintenanceVehiclesDetailService
    {
        Task<List<ResponseMaintenanceVehicleDetail>> GetAll();
        Task<List<ResponseMaintenanceVehicleDetail>> Create(CreateMainVehicleDetail createMainVehicle);
        Task<List<ResponseMaintenanceVehicleDetail>> GetListByVehicleId(Guid id);
    }
}
