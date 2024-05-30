using Infrastructure.Common.Request.RequestMaintenanceServiceInfo;
using Infrastructure.Common.Request.RequestMaintenanceSparePartInfor;
using Infrastructure.Common.Response.ResponseMaintenanceService;
using Infrastructure.Common.Response.ResponseMaintenanceSparePart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface IMaintenanceSparePartInfoService
    {
        Task<List<ResponseMaintenanceSparePartInfo>> GetAll();
        Task<ResponseMaintenanceSparePartInfo> GetById(Guid id);
        Task<ResponseMaintenanceSparePartInfo> Create(CreateMaintenanceSparePartInfo create);
    }
}
