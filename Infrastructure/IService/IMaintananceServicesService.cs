using Infrastructure.Common.Request.MaintananceServices;
using Infrastructure.Common.Request.RequestMaintananceServices;
using Infrastructure.Common.Response.ResponseMaintenanceSchedule;
using Infrastructure.Common.Response.ResponseServicesCare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface IMaintananceServicesService
    {
        Task<List<ResponseMaintananceServices>> GetAll();
        Task<ResponseMaintananceServices> GetById(Guid id);
        Task<ResponseMaintananceServices> Create(CreateMaintananceServices create);
        Task<List<ResponseMaintananceServices>> GetListByCenter();
        Task<List<ResponseMaintananceServices>> GetListByCenterId(Guid id);
        Task<ResponseMaintananceServices> Update(Guid id, UpdateMaintananceServices update);
        Task<ResponseMaintananceServices> UpdateStatus(Guid id, string status);
        Task<List<ResponseMaintananceServices>> GetListPackageByOdoAndCenterId(Guid id, Guid odoId);
        Task<List<ResponseMaintananceServices>> GetListPackageAndOdoTRUEByCenterId(Guid id);
        Task<List<ResponseMaintananceServices>> GetListPackageAndOdoTRUEByCenterIdAndModelId(Guid id, Guid modelId);
        Task<List<ResponseMaintananceServices>> GetListPackageOdoTRUEByCenterIdAndModelIdAndPlanId(Guid id, Guid modelId,Guid planId);
        Task<List<ResponseMaintananceServices>> GetListFalseByCenterIdAndModelId(Guid id, Guid modelId);
        
        Task<List<ResponseMaintananceServices>> Test(Guid id);
        Task<List<ResponseMaintananceServices>> CreateList(CreateMainServiceList create);

        Task Remove(Guid id);
    }
}
