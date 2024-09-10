using AutoMapper;
using Domain.Entities;
using Infrastructure.Common.Request.RequestMainVehicleDetail;
using Infrastructure.Common.Response.ResponseMVD;
using Infrastructure.ISecurity;
using Infrastructure.IUnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class MaintenanceVehiclesDetailServiceImp : IMaintenanceVehiclesDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokensHandler _tokensHandler;

        public MaintenanceVehiclesDetailServiceImp(IUnitOfWork unitOfWork, IMapper mapper, ITokensHandler tokensHandler)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokensHandler = tokensHandler;
        }

        public async Task<List<ResponseMaintenanceVehicleDetail>> Create(CreateMainVehicleDetail createMainVehicle)
        {
            var plan = await _unitOfWork.MaintenancePlanRepository.GetById(createMainVehicle.MaintanancePlanId);
            var veid = await _unitOfWork.Vehicles.GetById(createMainVehicle.VehiclesId);
            var list = await _unitOfWork.MaintenanceSchedule.GetListPackageByPlanId(plan.MaintenancePlanId);
            List<MaintenanceVehiclesDetail> mvds = new List<MaintenanceVehiclesDetail>();
            foreach (var mvd in list)
            {
                MaintenanceVehiclesDetail v = new MaintenanceVehiclesDetail
                {
                    DateTime = DateTime.Now,
                    Status = mvd.Status,
                    VehiclesId = veid.VehiclesId,
                    MaintananceScheduleId = mvd.MaintananceScheduleId,
                    MaintenanceCenterId = createMainVehicle.MaintenanceCenterId,
                };
                await _unitOfWork.MaintenanceVehiclesDetailRepository.Add(v);
                mvds.Add(v);
            }
            await _unitOfWork.Commit();
            return _mapper.Map<List<ResponseMaintenanceVehicleDetail>>(mvds);
        }

        public async Task<List<ResponseMaintenanceVehicleDetail>> GetAll()
        {
            return _mapper.Map<List<ResponseMaintenanceVehicleDetail>>(await _unitOfWork.MaintenanceVehiclesDetailRepository.GetAll());
        }

        public async Task<List<ResponseMaintenanceVehicleDetail>> GetListByVehicleId(Guid id)
        {
            return _mapper.Map<List<ResponseMaintenanceVehicleDetail>>(await _unitOfWork.MaintenanceVehiclesDetailRepository.GetListByVehicleId(id));
        }
    }
}
