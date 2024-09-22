using AutoMapper;
using Domain.Entities;
using Domain.Enum;
using Infrastructure.Common.Request.MaintenanceSchedule;
using Infrastructure.Common.Request.RequestMaintananceServices;
using Infrastructure.Common.Response.ResponseMaintenanceSchedule;
using Infrastructure.IUnitofWork;
using Infrastructure.IUnitofWork.Imp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class MaintenanceScheduleServiceImp : IMaintenanceScheduleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MaintenanceScheduleServiceImp(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseMaintenanceSchedules> Create(CreateMaintenanceSchedule create)
        {
            var maintanance_schedule = _mapper.Map<MaintananceSchedule>(create);



            //await _unitOfWork.VehicleModel.GetById(maintanance_schedule.MaintenancePlanId);

            maintanance_schedule.CreateDate = DateTime.Now;
            maintanance_schedule.Status = EnumStatus.ACTIVE.ToString();
            await _unitOfWork.MaintenanceSchedule.Add(maintanance_schedule);
            await _unitOfWork.Commit();

            return _mapper.Map<ResponseMaintenanceSchedules>(maintanance_schedule);
        }



        public async Task<List<ResponseMaintenanceSchedules>> GetAll()
        {
            return _mapper.Map<List<ResponseMaintenanceSchedules>>(await _unitOfWork.MaintenanceSchedule.GetAll());
        }

        public async Task<ResponseMaintenanceSchedules> GetById(Guid id)
        {
            var maintanance_schedule = await _unitOfWork.MaintenanceSchedule.GetByID(id);
            return _mapper.Map<ResponseMaintenanceSchedules>(maintanance_schedule);
        }

        public async Task<List<ResponseMaintenanceSchedules>> GetListPackageCenterId(Guid id)
        {
            return _mapper.Map<List<ResponseMaintenanceSchedules>>(await _unitOfWork.MaintenanceSchedule.GetListPackageByCenterId(id));
        }

        public async Task<List<ResponseMaintenanceSchedules>> GetListPlanIdAndOdoCenterId(Guid planId, Guid centerId)
        {
            return _mapper.Map<List<ResponseMaintenanceSchedules>>(await _unitOfWork.MaintenanceSchedule.GetListPlanIdAndOdoCenterId(planId, centerId));
        }

        public async Task<List<ResponseMaintenanceSchedules>> GetListPlanIdAndPackageCenterId(Guid planId, Guid id)
        {
            return _mapper.Map<List<ResponseMaintenanceSchedules>>(await _unitOfWork.MaintenanceSchedule.GetListPlanIdAndPackageCenterId(planId, id));
        }

        public async Task<List<ResponseMaintenanceSchedules>> GetListPlanIdAndPackageCenterIdBookingId(Guid planId, Guid id, Guid bookingId)
        {
            return _mapper.Map<List<ResponseMaintenanceSchedules>>(await _unitOfWork.MaintenanceSchedule.GetListPlanIdAndPackageCenterIdBookingId(planId, id, bookingId));
        }

        public async Task<ResponseMaintenanceSchedules> Update(Guid id, UpdateMaintananceSchedule update)
        {
            var item = await _unitOfWork.MaintenanceSchedule.GetByID(id);
            //await _unitOfWork.VehicleModel.GetById(item.VehicleModelId);
            item.Description = update.Description;
            item.MaintananceScheduleName = update.Odo;
            await _unitOfWork.MaintenanceSchedule.Update(item);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseMaintenanceSchedules>(item);
        }

        //public async Task<ResponseMaintenanceSchedule> UpdateStatus(Guid id, string status)
        //{
        //    var item = await _unitOfWork.MaintenanceSchedule.GetByID(id);
        //    item. = status;
        //    await _unitOfWork.MaintenanceSchedule.Update(item);
        //    await _unitOfWork.Commit();
        //    return _mapper.Map<ResponseMaintenanceSchedule>(item);
        //}
    }
}
