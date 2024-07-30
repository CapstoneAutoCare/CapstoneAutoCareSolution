using AutoMapper;
using Domain.Entities;
using Domain.Enum;
using Infrastructure.Common.Request.RequestMaintenanceServiceInfo;
using Infrastructure.Common.Response.ResponseMaintenanceService;
using Infrastructure.Common.Response.ResponseMaintenanceSparePart;
using Infrastructure.IUnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class MaintenanceServiceInfoServiceImp : IMaintenanceServiceInfoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MaintenanceServiceInfoServiceImp(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseMaintenanceServiceInfo> Create(CreateMaintenanceServiceInfo create)
        {
            var msi = _mapper.Map<MaintenanceServiceInfo>(create);
            msi.Status = EnumStatus.ACTIVE.ToString();
            msi.CreatedDate = DateTime.Now;
            msi.Discount = 0;
            msi.TotalCost = (msi.ActualCost * msi.Quantity) * (1 - (msi.Discount) / 100f);

            var i = await _unitOfWork.InformationMaintenance.GetById(msi.InformationMaintenanceId);
            i.TotalPrice += msi.TotalCost;
            await _unitOfWork.InformationMaintenance.Update(i);
            if (msi.MaintenanceServiceCostId == null)
            {
                await _unitOfWork.MaintenanceServiceInfo.Add(msi);
            }
            else
            {
                await _unitOfWork.MaintenanceServiceCost.GetById(msi.MaintenanceServiceCostId);
                await _unitOfWork.MaintenanceServiceInfo.Add(msi);
            }
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseMaintenanceServiceInfo>(msi);
        }

        public async Task<List<ResponseMaintenanceServiceInfo>> GetAll()
        {
            return _mapper.Map<List<ResponseMaintenanceServiceInfo>>(await _unitOfWork.MaintenanceServiceInfo.GetAll());
        }

        public async Task<ResponseMaintenanceServiceInfo> GetById(Guid id)
        {
            return _mapper.Map<ResponseMaintenanceServiceInfo>(await _unitOfWork.MaintenanceServiceInfo.GetById(id));
        }

        public async Task<ResponseMaintenanceServiceInfo> Update(Guid id, UpdateMaintenanceServiceInfoHaveItems infoHaveItems)
        {
            var msi = await _unitOfWork.MaintenanceServiceInfo.GetById(id);
            var money = msi.TotalCost;
            var u = _mapper.Map(infoHaveItems, msi);
            u.TotalCost = (msi.ActualCost * msi.Quantity) * (1 - (msi.Discount) / 100f);

            var i = await _unitOfWork.InformationMaintenance.GetById(msi.InformationMaintenanceId);

            i.TotalPrice -= money;
            i.TotalPrice += u.TotalCost;
            await _unitOfWork.MaintenanceServiceInfo.Update(u);
            await _unitOfWork.InformationMaintenance.Update(i);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseMaintenanceServiceInfo>(u);
        }

        public async Task<ResponseMaintenanceServiceInfo> UpdateStatus(Guid id, string status)
        {
            var mspi = await _unitOfWork.MaintenanceServiceInfo.GetById(id);
            var i = await _unitOfWork.InformationMaintenance.GetById(mspi.InformationMaintenanceId);

            if (mspi.Status.Equals(EnumStatus.ACTIVE.ToString())
                && status.Equals(EnumStatus.INACTIVE.ToString())
                && (!i.Status.Equals(EnumStatus.PAID.ToString())
                && !i.Status.Equals(EnumStatus.PAYMENT.ToString())))
            {
                mspi.Status = status;
                i.TotalPrice -= mspi.TotalCost;
                await _unitOfWork.MaintenanceServiceInfo.Update(mspi);
                await _unitOfWork.InformationMaintenance.Update(i);
                await _unitOfWork.Commit();
                return _mapper.Map<ResponseMaintenanceServiceInfo>(mspi);

            }
            else if (mspi.Status.Equals(EnumStatus.INACTIVE.ToString())
                && status.Equals(EnumStatus.ACTIVE.ToString())
                && (!i.Status.Equals(EnumStatus.PAID.ToString())
                && !i.Status.Equals(EnumStatus.PAYMENT.ToString())))
            {
                mspi.Status = status;
                i.TotalPrice += mspi.TotalCost;
                await _unitOfWork.MaintenanceServiceInfo.Update(mspi);
                await _unitOfWork.InformationMaintenance.Update(i);
                await _unitOfWork.Commit();
                return _mapper.Map<ResponseMaintenanceServiceInfo>(mspi);

            }
            else
            {
                throw new Exception("Can't change Status By Status in " + i.Status.ToString());
            }
        }
    }
}
