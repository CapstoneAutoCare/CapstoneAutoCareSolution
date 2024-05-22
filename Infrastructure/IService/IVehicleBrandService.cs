using Domain.Entities;
using Infrastructure.Common.Request.VehicleRequest;
using Infrastructure.IService.Imp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface IVehicleBrandService
    {
        Task<VehiclesBrand> CreateVehicleBrand(string vehiclesBrandName); 
        Task<VehiclesBrand> UpdateVehicleBrand(Guid BrandId, VehicleBrandUpdate vehiclesBrand);
        Task<VehiclesBrand> ChangeStatusVehicleBrand(Guid BrandId, string status);
        Task<VehiclesBrand> GetVehiclesBrandByID(Guid id);
        Task<List<VehiclesBrand>> GetAllVehiclesBrand();
    }
}
