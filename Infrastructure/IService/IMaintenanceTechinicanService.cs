using Infrastructure.Common.Request.RequestMaintenanceSparePartInfor;
using Infrastructure.Common.Request.RequestMaintenanceTechinican;
using Infrastructure.Common.Response.ResponseMaintenanceSparePart;
using Infrastructure.Common.Response.ResponseTechnicanMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface IMaintenanceTechinicanService
    {
        Task<List<ResponseMaintenanceTask>> GetAll();
        Task<ResponseMaintenanceTask> GetById(Guid id);
        Task<ResponseMaintenanceTask> Create(CreateMaintenanceTechinican create);
        Task<ResponseMaintenanceTask> UpdateStatus(Guid id, string status);
        Task<List<ResponseMaintenanceTask>> GetListByCenter();
        Task<List<ResponseMaintenanceTask>> GetListByCustomerCare();
        Task<List<ResponseMaintenanceTask>> GetListByTechnician();
    }
}
