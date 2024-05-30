﻿using AutoMapper;
using Domain.Entities;
using Infrastructure.Common.Request.RequestMaintenanceServiceInfo;
using Infrastructure.Common.Response.ResponseMaintenanceService;
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
            msi.Status = "INACTIVE";
            msi.CreatedDate = DateTime.Now;
            msi.Discount = 10;
            await _unitOfWork.InformationMaintenance.GetById(msi.InformationMaintenanceId);
            if (msi.MaintenanceServiceId == null)
            {
                await _unitOfWork.MaintenanceServiceInfo.Add(msi);
            }
            else
            {
                await _unitOfWork.MaintenanceService.GetById(msi.MaintenanceServiceId);
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
    }
}