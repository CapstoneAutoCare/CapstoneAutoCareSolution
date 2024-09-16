using Azure;
using Infrastructure.Common.Request.MaintenancePlan;
using Infrastructure.Common.Response.MaintenancePlanResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface IMaintenancePlanService
    {
        Task<List<ResponseMaintenancePlan>> GetAll();
        Task<ResponseMaintenancePlan> Create(CreateMaintanancePlan createMaintanancePlan);
        Task<ResponseMaintenancePlan> GetById(Guid id);
        Task<ResponseMaintenancePlan> Update(UpdateMaintanancePlan updateMaintanancePlan);
        Task<List<ResponseMaintenancePlan>> GetListByCenterId(Guid id);
    }
}
