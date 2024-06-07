using AutoMapper;
using Domain.Entities;
using Infrastructure.Common.Request.MaintananceServices;
using Infrastructure.Common.Response.ResponseServicesCare;
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

            maintanance_services.CreatedDate = DateTime.Now;
            maintanance_services.Status = "ACTIVE";
            await _unitOfWork.MaintenanceCenter.GetById(maintanance_services.MaintenanceCenterId);

            if (maintanance_services.ServiceCareId == null)
            {
                await _unitOfWork.MaintenanceService.Add(maintanance_services);
                await _unitOfWork.Commit();
            }
            else
            {
                await _unitOfWork.ServiceCare.GetByID(maintanance_services.ServiceCareId);
                await _unitOfWork.MaintenanceService.Add(maintanance_services);
                await _unitOfWork.Commit();
            }


            return _mapper.Map<ResponseMaintananceServices>(maintanance_services);
        }

        public async Task<List<ResponseMaintananceServices>> GetAll()
        {
            return _mapper.Map<List<ResponseMaintananceServices>>(await _unitOfWork.MaintenanceService.GetAll());
        }

        public async Task<ResponseMaintananceServices> GetById(Guid id)
        {
            var maintanance_services = await _unitOfWork.MaintenanceService.GetById(id);
            return _mapper.Map<ResponseMaintananceServices>(maintanance_services);
        }

        public async Task<ResponseMaintananceServices> Update(Guid id, UpdateMaintananceServices update)
        {
            var item = await _unitOfWork.MaintenanceService.GetById(id);
            item.ServiceCareId = update.ServiceCareId;
            //item.ActuralCost = update.ActuralCost;
            item.MaintenanceCenterId = update.MaintenanceCenterId;
            await _unitOfWork.MaintenanceService.Update(item);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseMaintananceServices>(item);
        }

        public async Task<ResponseMaintananceServices> UpdateStatus(Guid id, string status)
        {
            var item = await _unitOfWork.MaintenanceService.GetById(id);
            item.Status = status;
            await _unitOfWork.MaintenanceService.Update(item);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseMaintananceServices>(item);
        }
    }
}
