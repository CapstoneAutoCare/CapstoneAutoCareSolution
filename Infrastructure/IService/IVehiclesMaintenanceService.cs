using Domain.Entities;
using Infrastructure.Common.Request.VMRequest;
using Infrastructure.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface IVehiclesMaintenanceService
    {
        Task<List<ResponseVehiclesMaintenance>> GetList();
        Task<List<ResponseVehiclesMaintenance>> CreateList(CreateVehicleMain vehicleMain);
        Task<List<ResponseVehiclesMaintenance>> GetListByCenter(Guid id);
    }
}
