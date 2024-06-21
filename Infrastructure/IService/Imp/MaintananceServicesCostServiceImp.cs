using AutoMapper;
using Domain.Entities;
using Domain.Enum;
using Infrastructure.Common.Request.RequestMaintenanceServiceCost;
using Infrastructure.Common.Response.ResponseCost;
using Infrastructure.Common.Response.ResponseHistoryStatus;
using Infrastructure.IUnitofWork;
using Infrastructure.IUnitofWork.Imp;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class MaintananceServicesCostServiceImp : IMaintananceServicesCostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MaintananceServicesCostServiceImp(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseMaintenanceServiceCost> Create(CreateMaintenanceServiceCost create)
        {
            var cost = _mapper.Map<MaintenanceServiceCost>(create);
            cost.Status = EnumStatus.INACTIVE.ToString();
            cost.DateTime = DateTime.UtcNow;
            await _unitOfWork.MaintenanceService.GetById(cost.MaintenanceServiceId);
            await _unitOfWork.MaintenanceServiceCost.Add(cost);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseMaintenanceServiceCost>(cost);
        }

        public async Task<List<ResponseMaintenanceServiceCost>> GetAll()
        {
            return _mapper.Map<List<ResponseMaintenanceServiceCost>>(await _unitOfWork.MaintenanceServiceCost.GetAll());
        }

        public async Task<ResponseMaintenanceServiceCost> GetById(Guid id)
        {
            return _mapper.Map<ResponseMaintenanceServiceCost>(await _unitOfWork.MaintenanceServiceCost.GetById(id));
        }

        public async Task<List<ResponseMaintenanceServiceCost>> GetListByVIEWClient(Guid centerId)
        {
            return _mapper.Map<List<ResponseMaintenanceServiceCost>>(
                           await _unitOfWork.MaintenanceServiceCost.GetListByStatusAndStatusCost(EnumStatus.ACTIVE.ToString(), EnumStatus.ACTIVE.ToString(),centerId));
        }

        public async Task<ResponseMaintenanceServiceCost> UpdateStatus(Guid id, string status)
        {
            var cost = await _unitOfWork.MaintenanceServiceCost.GetById(id);
            cost.Status = status;
            await _unitOfWork.MaintenanceServiceCost.Update(cost);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseMaintenanceServiceCost>(cost);
        }
    }
}
