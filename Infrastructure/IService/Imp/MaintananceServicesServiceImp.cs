using AutoMapper;
using Domain.Entities;
using Infrastructure.Common.Request.MaintananceServices;
using Infrastructure.Common.Response.ReponseMaintenancePlan;
using Infrastructure.Common.Response.ReponseServicesCare;
using Infrastructure.IUnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class MaintananceServicesServiceImp : IMaintananceServicesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MaintananceServicesServiceImp(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseMaintananceServices> Create(CreateMaintananceServices create)
        {
            var maintanance_services = _mapper.Map<MaintenanceService>(create);
            await _unitOfWork.MaintenanceService.GetByID(maintanance_services.ServiceCareId);
            await _unitOfWork.MaintenanceCenter.GetById(maintanance_services.MaintenanceCenterId);


            maintanance_services.CreatedDate = DateTime.Now;
            maintanance_services.Status = "ACTIVE";

            await _unitOfWork.MaintenanceService.Add(maintanance_services);
            // chưa vo unit mở nó lên
            await _unitOfWork.Commit();

            return _mapper.Map<ResponseMaintananceServices>(maintanance_services);
        }

        public async Task<List<ResponseMaintananceServices>> GetAll()
        {
            return _mapper.Map<List<ResponseMaintananceServices>>(await _unitOfWork.MaintenanceService.GetAll());
        }

        public async Task<ResponseMaintananceServices> GetById(Guid id)
        {
            var maintanance_services = await _unitOfWork.MaintenanceService.GetByID(id);
            return _mapper.Map<ResponseMaintananceServices>(maintanance_services);
        }
    }
}
