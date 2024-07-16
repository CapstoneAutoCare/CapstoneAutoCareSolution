using Infrastructure.Common.Request.RequestMaintenanceHistoryStatus;
using Infrastructure.Common.Response.ResponseCost;
using Infrastructure.Common.Response.ResponseHistoryStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface IMaintenanceHistoryStatusService
    {
        Task<List<ResponseMaintenanceHistoryStatus>> GetAll();
        Task<ResponseMaintenanceHistoryStatus> GetById(Guid id);
        Task<ResponseMaintenanceHistoryStatus> Create(CreateMaintenanceHistoryStatus create);
        Task<ResponseMaintenanceHistoryStatus> Update(Guid id, CreateMaintenanceHistoryStatus update);
        //Task<ResponseMaintenanceHistoryStatus> GetListByCenterAndStatusCheckin(Guid id, string status);

        Task Delete(Guid id);

    }
}
