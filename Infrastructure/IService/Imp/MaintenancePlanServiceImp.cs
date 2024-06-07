﻿using AutoMapper;
using Domain.Entities;
using Infrastructure.Common.Request.MaintenancePlan;
using Infrastructure.Common.Response.ReponseMaintenancePlan;
using Infrastructure.Common.Response.ReponseMaintenanceSchedule;
using Infrastructure.Common.Response.ReponseServicesCare;
using Infrastructure.Common.Response.ReponseSparePart;
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
            maintanance_plan.Status = "ACTIVE";
            maintanance_plan.CreateDate = DateTime.Now;

            await _unitOfWork.MaintenancePlan.Add(maintanance_plan);
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

        public async Task<ResponseMaintenancePlan> Update(Guid id, UpdateMaintanancePlan update)
        {
            var item = await _unitOfWork.MaintenancePlan.GetByID(id);
            item.MaintenancePlanName = update.MaintenancePlanName;
            item.MaintenancePlanDescription = update.MaintenancePlanDescription;
            item.MaintananceScheduleId = update.MaintananceScheduleId;
            await _unitOfWork.MaintenancePlan.Update(item);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseMaintenancePlan>(item);
        }

        public async Task<ResponseMaintenancePlan> UpdateStatus(Guid id, string status)
        {
            var item = await _unitOfWork.MaintenancePlan.GetByID(id);
            item.Status = status;
            await _unitOfWork.MaintenancePlan.Update(item);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseMaintenancePlan>(item);
        }
    }
}
