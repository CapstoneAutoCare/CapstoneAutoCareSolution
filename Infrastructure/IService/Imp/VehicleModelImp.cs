using AutoMapper;
using Domain.Entities;
using Infrastructure.Common.Request.VehicleModel;
using Infrastructure.Common.Response.ReponseVehicleModel;
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

        public async Task<ReponseVehicleModel> CreateNewVehicleModel(CreateVehicleModel vehicleModel)
        {
            var model = _mapper.Map<VehicleModel>(vehicleModel);
            model.CreatedDate = DateTime.Now;
            model.Status = "ACTIVE";
            await _unitofWork.VehicleModel.Add(model);
            await _unitofWork.Commit();
            return _mapper.Map<ReponseVehicleModel>(model);
        }

        

        public async Task<List<ReponseVehicleModel>> GetAllVehiclesModels()
        {
            var models = await _unitofWork.VehicleModel.GetAll();
            return _mapper.Map<List<ReponseVehicleModel>>(models);
        }

        public async Task<ReponseVehicleModel> GetVehicleById(Guid id)
        {
            var model = await _unitofWork.VehicleModel.GetById(id);
            return _mapper.Map<ReponseVehicleModel>(model);
        }

        public async Task<ReponseVehicleModel> UpdateStatusVehicleModel(Guid id ,string status)
        {
            var model = await _unitofWork.VehicleModel.GetById(id);
            model.Status = status.ToUpper();
            await _unitofWork.VehicleModel.Update(model);
            await _unitofWork.Commit();
            return _mapper.Map<ReponseVehicleModel>(model);
        }

        public async Task<ReponseVehicleModel> UpdateVehicleModel(Guid id, UpdateVehicleModel vehicleModel)
        {
            var model = await _unitofWork.VehicleModel.GetById(id);
            model.VehicleModelName = vehicleModel.VehicleModelName;
            model.VehiclesBrandId = vehicleModel.VehiclesBrandId;
            model.Image = vehicleModel.Image;
            return _mapper.Map<ReponseVehicleModel>(model);
        }
    }
}
