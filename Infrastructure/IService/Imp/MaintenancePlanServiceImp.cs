using AutoMapper;
using Domain.Entities;
using Domain.Enum;
using Infrastructure.Common.Request.MaintenancePlan;
using Infrastructure.Common.Response.ResponseMaintenancePlan;
using Infrastructure.ISecurity;
using Infrastructure.IUnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class MaintenancePlanServiceImp : IMaintenancePlanService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokensHandler _tokensHandler;

        public MaintenancePlanServiceImp(IUnitOfWork unitOfWork, IMapper mapper, ITokensHandler tokensHandler)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokensHandler = tokensHandler;
        }

        public async Task<ResponseMaintenancePlan> Create(CreateMaintanancePlan createMaintanancePlan)
        {
            var mp = _mapper.Map<MaintenancePlan>(createMaintanancePlan);
            await _unitOfWork.VehicleModel.GetById(mp.VehicleModelId);
            mp.Status = EnumStatus.ACTIVE.ToString();
            mp.DateTime = DateTime.Now;
            await _unitOfWork.MaintenancePlanRepository.Add(mp);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseMaintenancePlan>(mp);
        }

        public async Task<List<ResponseMaintenancePlan>> GetAll()
        {
            return _mapper.Map<List<ResponseMaintenancePlan>>(await _unitOfWork.MaintenancePlanRepository.GetAll());
        }

        public async Task<ResponseMaintenancePlan> GetById(Guid id)
        {
            return _mapper.Map<ResponseMaintenancePlan>(await _unitOfWork.MaintenancePlanRepository.GetById(id));
        }

        public async Task<List<ResponseMaintenancePlan>> GetListByCenterId(Guid id)
        {
            return _mapper.Map<List<ResponseMaintenancePlan>>(await _unitOfWork.MaintenancePlanRepository.GetListCenterId(id));
        }

        public Task<ResponseMaintenancePlan> Update(UpdateMaintanancePlan updateMaintanancePlan)
        {
            throw new NotImplementedException();
        }
    }
}
