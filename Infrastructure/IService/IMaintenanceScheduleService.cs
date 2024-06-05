using Infrastructure.Common.Request.MaintenanceSchedule;
using Infrastructure.Common.Request.Sparepart;
using Infrastructure.Common.Response.ReponseMaintenanceSchedule;
using Infrastructure.Common.Response.ReponseSparePart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface IMaintenanceScheduleService
    {
        Task<List<ResponseMaintenanceSchedule>> GetAll();
        Task<ResponseMaintenanceSchedule> GetById(Guid id);
        Task<ResponseMaintenanceSchedule> Create(CreateMaintenanceSchedule create);
        Task<ResponseMaintenanceSchedule> Update(Guid id, UpdateMaintananceSchedule update);
        Task<ResponseMaintenanceSchedule> UpdateStatus(Guid id, string status);
    }
}
