using AutoMapper;
using Domain.Entities;
using Infrastructure.Common.Request.VMRequest;
using Infrastructure.Common.Response;
using Infrastructure.IUnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class VehiclesMaintenanceServiceImp : IVehiclesMaintenanceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VehiclesMaintenanceServiceImp(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ResponseVehiclesMaintenance>> CreateList(CreateVehicleMain vehicleMain)
        {
            var center = await _unitOfWork.MaintenanceCenter.GetById(vehicleMain.MaintenanceCenterId);
            List<VehiclesMaintenance> vehiclesMain = new List<VehiclesMaintenance>();
            foreach (var i in vehicleMain.VehiclesBrandIds)
            {
                await _unitOfWork.VehiclesBrand.GetById(i);
                VehiclesMaintenance vehiclesMaintenance = new VehiclesMaintenance()
                {
                    MaintenanceCenterId = center.MaintenanceCenterId,
                    VehiclesBrandId = i
                };
                vehiclesMain.Add(vehiclesMaintenance);
                await _unitOfWork.VehiclesMaintenance.Add(vehiclesMaintenance);

            }
            await _unitOfWork.Commit();
            return _mapper.Map<List<ResponseVehiclesMaintenance>>(vehiclesMain);
        }

        public async Task<List<ResponseVehiclesMaintenance>> GetList()
        {
            return _mapper.Map<List<ResponseVehiclesMaintenance>>(await _unitOfWork.VehiclesMaintenance.GetAll());
        }

        public async Task<List<ResponseVehiclesMaintenance>> GetListByCenter(Guid id)
        {
            return _mapper.Map<List<ResponseVehiclesMaintenance>>(await _unitOfWork.VehiclesMaintenance.GetListByCenter(id));
        }
    }
}
