using Infrastructure.Common.Request.MaintenanceSchedule;
using Infrastructure.Common.Response.ReponseMaintenanceSchedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface IMaintenanceScheduleService
    {
        Task<List<ReponseMaintenanceSchedule>> GetAll();
        Task<ReponseMaintenanceSchedule> GetById(Guid id);
        Task<ReponseMaintenanceSchedule> Create(CreateMaintenanceSchedule create);
    }
}
