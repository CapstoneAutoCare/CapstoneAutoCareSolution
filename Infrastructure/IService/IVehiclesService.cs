using Infrastructure.Common.Request.RequestVehicles;
using Infrastructure.Common.Response.ResponseBooking;
using Infrastructure.Common.Response.VehiclesResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface IVehiclesService
    {
        Task<List<ResponseVehicles>> GetAll();
        Task<ResponseVehicles> Create(CreateVehicle create);
        Task<ResponseVehicles> GetById(Guid id);
        Task<List<ResponseVehicles>> GetListByClient();
        Task<ResponseVehicles> UpdateStatus(Guid id, string status);
        Task<ResponseVehicles> Update(Guid id, UpdateVehicle updateVehicle);
        Task<List<ResponseVehicles>> GetListByCenterWhenBuyPackage(Guid centerId);
    }
}
