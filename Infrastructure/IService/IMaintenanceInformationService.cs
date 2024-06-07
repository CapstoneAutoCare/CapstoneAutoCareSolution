using Infrastructure.Common.Request.RequestMaintenanceInformation;
using Infrastructure.Common.Response.ResponseMainInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface IMaintenanceInformationService
    {
        Task<ResponseMaintenanceInformation> GetById(Guid id);
        Task<ResponseMaintenanceInformation> Create(CreateMaintenanceInformation create);
        Task<ResponseMaintenanceInformation> CreateHaveItems(CreateMaintenanceInformationHaveItems create);
        Task<List<ResponseMaintenanceInformation>> GetAll();
    }
}
