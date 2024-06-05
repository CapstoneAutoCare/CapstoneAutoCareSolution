using Infrastructure.Common.Request.MaintananceServices;
using Infrastructure.Common.Request.Sparepart;
using Infrastructure.Common.Response.ReponseServicesCare;
using Infrastructure.Common.Response.ReponseSparePart;
using Infrastructure.Common.Response.ResponseMaintenanceService;
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
        Task<ResponseMaintananceServices> Update(Guid id, UpdateMaintananceServices update);
        Task<ResponseMaintananceServices> UpdateStatus(Guid id, string status);
    }
}
