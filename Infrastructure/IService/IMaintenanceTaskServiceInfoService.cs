using Domain.Entities;
using Infrastructure.Common.Request.RequestMaintenanceTechinican;
using Infrastructure.Common.Response.ResponseTechnicanMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface IMaintenanceTaskServiceInfoService
    {
        Task<ResponseMainTaskService> GetById(Guid id);
        Task<List<ResponseMainTaskService>> GetAll(Guid id);
        Task<List<ResponseMainTaskService>> Create(CreateMaintenanceTaskServiceInfo create);
        Task<ResponseMainTaskService> ChangeStatus(Guid id, string status);

    }
}
