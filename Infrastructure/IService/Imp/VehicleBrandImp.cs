using AutoMapper;
using Domain.Entities;
using Domain.Enum;
using Infrastructure.Common.Request.RequestVehicleBrandRequest;
using Infrastructure.Common.Request.VehicleBrandRequest;
using Infrastructure.IUnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class VehicleBrandImp : IVehicleBrandService
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly IMapper _mapper;

        public VehicleBrandImp(IUnitOfWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }
        public async Task<VehiclesBrand> ChangeStatusVehicleBrand(Guid BrandId, string status)
        {
            var brand = await _unitofWork.VehiclesBrand.GetById(BrandId);
            brand.Status = status;
            await _unitofWork.VehiclesBrand.Update(brand);
            await _unitofWork.Commit();
            return brand;
        }

        public async Task<VehiclesBrand> CreateVehicleBrand(CreateBrand create)
        {
            var brand = _mapper.Map<VehiclesBrand>(create);
            brand.Status = EnumStatus.ACTIVE.ToString();
            brand.CreatedDate = DateTime.Now;
            await _unitofWork.VehiclesBrand.Add(brand);
            await _unitofWork.Commit();
            return brand;
        }

        public async Task<List<VehiclesBrand>> GetAllVehiclesBrand()
        {
            var brand = await _unitofWork.VehiclesBrand.GetAll();
            //var brandView = _mapper.Map<List<VehiclesBrand>>(brand);
            return brand;
        }

        public async Task<VehiclesBrand> GetVehiclesBrandByID(Guid id)
        {
            var brand = await _unitofWork.VehiclesBrand.GetById(id);
            return brand;
        }

        public async Task<VehiclesBrand> UpdateVehicleBrand(Guid BrandId, VehicleBrandUpdate update)
        {
            var brand = await _unitofWork.VehiclesBrand.GetById(BrandId);
            brand.VehiclesBrandName = update.BrandName;
            await _unitofWork.VehiclesBrand.Update(brand);
            await _unitofWork.Commit();
            return brand;
        }
    }
}
