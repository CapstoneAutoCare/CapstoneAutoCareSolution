using AutoMapper;
using Domain.Entities;
using Infrastructure.Common.Request.RequestMaintenanceSparePartInfor;
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
    public class MaintenanceSparePartInfoServiceImp : IMaintenanceSparePartInfoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MaintenanceSparePartInfoServiceImp(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseMaintenanceSparePartInfo> Create(CreateMaintenanceSparePartInfo create)
        {
            var spi = _mapper.Map<MaintenanceSparePartInfo>(create);
            spi.Status = "INACTIVE";
            spi.CreatedDate = DateTime.Now;
            spi.Discount = 10;
            spi.TotalCost = (spi.ActualCost * spi.Quantity) * (1 - (spi.Discount) / 100);
            await _unitOfWork.InformationMaintenance.GetById(spi.InformationMaintenanceId);
            if (spi.SparePartsItemId == null)
            {
                await _unitOfWork.MaintenanceSparePartInfo.Add(spi);
            }
            else
            {
                await _unitOfWork.MaintenanceService.GetById(spi.SparePartsItemId);
                await _unitOfWork.MaintenanceSparePartInfo.Add(spi);
            }
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseMaintenanceSparePartInfo>(spi);
        }

        public async Task<List<ResponseMaintenanceSparePartInfo>> GetAll()
        {
            return _mapper.Map<List<ResponseMaintenanceSparePartInfo>>(await _unitOfWork.MaintenanceSparePartInfo.GetAll());
        }

        public async Task<ResponseMaintenanceSparePartInfo> GetById(Guid id)
        {
            return _mapper.Map<ResponseMaintenanceSparePartInfo>(await _unitOfWork.MaintenanceSparePartInfo.GetById(id));
        }
    }
}
