using Infrastructure.Common.Request.RequestMaintenanceTechinican;
using Infrastructure.Common.Request.RequestOdo;
using Infrastructure.Common.Response.OdoResponse;
using Infrastructure.Common.Response.ResponseTechnicanMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface IOdoHistoryService
    {
        Task<List<ResponseOdoHistory>> GetAll();
        Task<ResponseOdoHistory> GetById(Guid id);
        Task<ResponseOdoHistory> Create(CreateOdoHistory create);
        Task<ResponseOdoHistory> Update(Guid id, UpdateOdo updateOdo);
        Task<ResponseOdoHistory> GetByInforId(Guid id);
    }
}
