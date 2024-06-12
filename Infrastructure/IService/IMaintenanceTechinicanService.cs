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
        Task<List<ResponseMaintenanceTechinican>> GetAll();
        Task<ResponseMaintenanceTechinican> GetById(Guid id);
        Task<ResponseMaintenanceTechinican> Create(CreateMaintenanceTechinican create);
    }
}
