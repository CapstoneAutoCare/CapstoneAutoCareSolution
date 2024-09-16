using Infrastructure.Common.Request.MaintenanceSchedule;
using Infrastructure.Common.Request.RequestMaintananceServices;
using Infrastructure.Common.Response.ResponseMaintenanceSchedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface IMaintenanceScheduleService
    {
        Task<List<ResponseMaintenanceSchedules>> GetAll();
        Task<ResponseMaintenanceSchedules> GetById(Guid id);
        Task<List<ResponseMaintenanceSchedules>> GetListPackageCenterId(Guid id);
        Task<List<ResponseMaintenanceSchedules>> GetListPlanIdAndPackageCenterId(Guid planId,Guid id);

        Task<List<ResponseMaintenanceSchedules>> GetListPlanIdAndPackageCenterIdBookingId(Guid planId, Guid id,Guid bookingId);
        
        Task<ResponseMaintenanceSchedules> Create(CreateMaintenanceSchedule create);
        Task<ResponseMaintenanceSchedules> Update(Guid id, UpdateMaintananceSchedule update);
       // Task<ResponseMaintenanceSchedule> UpdateStatus(Guid id, string status);

    }
}
