using Domain.Entities;
using Infrastructure.Common.Request.RequestVehicleBrandRequest;
using Infrastructure.Common.Request.VehicleBrandRequest;
using Infrastructure.Common.Response;
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
        Task<VehiclesBrand> CreateVehicleBrand(CreateBrand createBrand); 
        Task<VehiclesBrand> UpdateVehicleBrand(Guid BrandId, VehicleBrandUpdate vehiclesBrand);
        Task<VehiclesBrand> ChangeStatusVehicleBrand(Guid BrandId, string status);
        Task<VehiclesBrand> GetVehiclesBrandByID(Guid id);
        Task<List<VehiclesBrand>> GetAllVehiclesBrand();
        Task<List<VehiclesBrand>> GetListBrandActive();
        Task<List<ResponseBrand>> GetBrandsNotInCenter(Guid centerId);
    }
}
