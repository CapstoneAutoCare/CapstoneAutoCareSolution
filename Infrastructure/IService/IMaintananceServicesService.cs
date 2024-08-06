using Infrastructure.Common.Request.MaintananceServices;
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
        Task Remove(Guid id);
    }
}
