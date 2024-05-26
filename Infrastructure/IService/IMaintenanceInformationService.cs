using Infrastructure.Common.Request.MaintenanceInformation;
using Infrastructure.Common.Response.ResponseMaintenanceInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface IMaintenanceInformationService
    {
        Task<ResponseMaintenanceInformation> GetById (Guid id);
        Task<ResponseMaintenanceInformation> Create(CreateMaintenanceInformation create);
        Task<List<ResponseMaintenanceInformation>> GetAll();
    }
}
