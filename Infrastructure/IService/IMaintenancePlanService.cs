using Domain.Entities;
using Infrastructure.Common.Request.MaintenancePlan;
using Infrastructure.Common.Request.MaintenanceSchedule;
using Infrastructure.Common.Response.ReponseMaintenancePlan;
using Infrastructure.Common.Response.ReponseMaintenanceSchedule;
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
        Task<ResponseMaintenancePlan> GetById(Guid id);
        Task<ResponseMaintenancePlan> Create(CreateMaintanancePlan create);
        Task<ResponseMaintenancePlan> Update(Guid id, UpdateMaintanancePlan update);
        Task<ResponseMaintenancePlan> UpdateStatus(Guid id, string status);
    }
}
