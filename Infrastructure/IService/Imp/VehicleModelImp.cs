using AutoMapper;
using Domain.Entities;
using Infrastructure.Common.Request.VehicleModel;
using Infrastructure.Common.Response.ReponseVehicleModel;
using Infrastructure.Common.Response.VehiclesResponse;
using Infrastructure.IUnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class VehicleModelImp : IVehicleModelService
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly IMapper _mapper;
        public VehicleModelImp(IUnitOfWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }

        public async Task<ReponseVehicleModels> CreateNewVehicleModel(CreateVehicleModel vehicleModel)
        {
            var model = _mapper.Map<VehicleModel>(vehicleModel);
            await _unitofWork.VehiclesBrand.GetById(model.VehiclesBrandId);

            model.CreatedDate = DateTime.Now;
            model.Status = "ACTIVE";
            await _unitofWork.VehicleModel.CheckExist(model.VehicleModelName);
            await _unitofWork.VehicleModel.Add(model);
            await _unitofWork.Commit();
            return _mapper.Map<ReponseVehicleModels>(model);
        }



        public async Task<List<ReponseVehicleModels>> GetAllVehiclesModels()
        {
            var models = await _unitofWork.VehicleModel.GetAll();
            return _mapper.Map<List<ReponseVehicleModels>>(models);
        }

        public async Task<List<ReponseVehicleModels>> GetListByBrandIdActive(Guid id)
        {
            var models = await _unitofWork.VehicleModel.GetListActiveByBrandId(id);
            return _mapper.Map<List<ReponseVehicleModels>>(models);
        }

        public async Task<List<ReponseVehicleModels>> GetListVehicleByBrandId(Guid id)
        {
            var models = await _unitofWork.VehicleModel.GetListByBrandId(id);
            return _mapper.Map<List<ReponseVehicleModels>>(models);
        }

        public async Task<ReponseVehicleModels> GetVehicleById(Guid id)
        {
            var model = await _unitofWork.VehicleModel.GetById(id);
            return _mapper.Map<ReponseVehicleModels>(model);
        }

        public async Task<ReponseVehicleModels> UpdateStatusVehicleModel(Guid id, string status)
        {
            var model = await _unitofWork.VehicleModel.GetById(id);
            model.Status = status.ToUpper();
            await _unitofWork.VehicleModel.Update(model);
            await _unitofWork.Commit();
            return _mapper.Map<ReponseVehicleModels>(model);
        }

        public async Task<ReponseVehicleModels> UpdateVehicleModel(Guid id, UpdateVehicleModel vehicleModel)
        {
            var model = await _unitofWork.VehicleModel.GetById(id);
            model.VehicleModelName = vehicleModel.VehicleModelName;
            model.VehiclesBrandId = vehicleModel.VehiclesBrandId;
            model.Image = vehicleModel.Image;
            return _mapper.Map<ReponseVehicleModels>(model);
        }
    }
}
