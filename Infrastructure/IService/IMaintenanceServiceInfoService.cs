using Infrastructure.Common.Request.MaintenanceSchedule;
using Infrastructure.Common.Request.RequestMaintenanceServiceInfo;
using Infrastructure.Common.Response.ResponseMaintenanceService;
using Infrastructure.Common.Response.ResponseMaintenanceSparePart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface IMaintenanceServiceInfoService
    {
        Task<List<ResponseMaintenanceServiceInfo>> GetAll();
        Task<ResponseMaintenanceServiceInfo> GetById(Guid id);
        Task<ResponseMaintenanceServiceInfo> Create(CreateMaintenanceServiceInfo create);
        Task<ResponseMaintenanceServiceInfo> UpdateStatus(Guid id, string status);
        Task<ResponseMaintenanceServiceInfo> Update(Guid id, UpdateMaintenanceServiceInfoHaveItems infoHaveItems);

    }
}
