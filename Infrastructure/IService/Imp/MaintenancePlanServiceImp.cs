using AutoMapper;
using Domain.Entities;
using Infrastructure.Common.Request.MaintenancePlan;
using Infrastructure.Common.Response.ReponseMaintenancePlan;
using Infrastructure.Common.Response.ReponseMaintenanceSchedule;
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
        public MaintenancePlanServiceImp(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseMaintenancePlan> Create(CreateMaintanancePlan create)
        {
            var maintanance_plan = _mapper.Map<MaintenancePlan>(create);
            await _unitOfWork.MaintenanceSchedule.GetByID(maintanance_plan.MaintananceScheduleId);

            maintanance_plan.CreateDate = DateTime.Now;

            await _unitOfWork.MaintenancePlan.Add(maintanance_plan);
            // chưa vo unit mở nó lên
            await _unitOfWork.Commit();

            return _mapper.Map<ResponseMaintenancePlan>(maintanance_plan);
        }

        public async Task<List<ResponseMaintenancePlan>> GetAll()
        {
            return _mapper.Map<List<ResponseMaintenancePlan>>(await _unitOfWork.MaintenancePlan.GetAll());
        }

        public async Task<ResponseMaintenancePlan> GetById(Guid id)
        {
            var maintanance_plan = await _unitOfWork.MaintenancePlan.GetByID(id);
            return _mapper.Map<ResponseMaintenancePlan>(maintanance_plan);
        }
    }
}
