using AutoMapper;
using Domain.Entities;
using Infrastructure.Common.Request.MaintenanceSchedule;
using Infrastructure.Common.Response.ReponseMaintenanceSchedule;
using Infrastructure.Common.Response.ResponseClient;
using Infrastructure.IUnitofWork;
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
        public async Task<ReponseMaintenanceSchedule> Create(CreateMaintenanceSchedule create)
        {
            var maintanance_schedule = _mapper.Map<MaintananceSchedule>(create);
            await _unitOfWork.VehicleModel.GetById(maintanance_schedule.VehicleModelId);

            maintanance_schedule.CreateDate = DateTime.Now;

            await _unitOfWork.MaintenanceSchedule.Add(maintanance_schedule);
            // chưa vo unit mở nó lên
            await _unitOfWork.Commit();

            return _mapper.Map<ReponseMaintenanceSchedule>(maintanance_schedule);
        }

        public async Task<List<ReponseMaintenanceSchedule>> GetAll()
        {            return _mapper.Map<List<ReponseMaintenanceSchedule>>(await _unitOfWork.MaintenanceSchedule.GetAll());
        }

        public async Task<ReponseMaintenanceSchedule> GetById(Guid id)
        {
            var maintanance_schedule = await _unitOfWork.MaintenanceSchedule.GetByID(id);
            return _mapper.Map<ReponseMaintenanceSchedule>(maintanance_schedule);
        }
    }
}
