using Infrastructure.Common.Request.RequestMaintenanceServiceCost;
using Infrastructure.Common.Request.RequestSparePartsItemCost;
using Infrastructure.Common.Response.ResponseCost;
using Infrastructure.Common.Response.ResponseHistoryStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface IMaintananceServicesCostService
    {
        Task<List<ResponseMaintenanceServiceCost>> GetAll();
        Task<List<ResponseMaintenanceServiceCost>> GetListByVIEWClient();

        Task<ResponseMaintenanceServiceCost> GetById(Guid id);
        Task<ResponseMaintenanceServiceCost> Create(CreateMaintenanceServiceCost create);
        Task<ResponseMaintenanceServiceCost> UpdateStatus(Guid id, string status);

    }
}
