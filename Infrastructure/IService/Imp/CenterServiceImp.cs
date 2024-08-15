using AutoMapper;
using Domain.Entities;
using Domain.Enum;
using Infrastructure.Common.Request.RequestAccount;
using Infrastructure.Common.Response.DashBoard;
using Infrastructure.Common.Response.ReponseVehicleModel;
using Infrastructure.IUnitofWork;
using Infrastructure.IUnitofWork.Imp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class CenterServiceImp : ICenterService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CenterServiceImp(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseCenter> Create(CreateCenter create)
        {
            var centre = _mapper.Map<MaintenanceCenter>(create);
            centre.Account.CreatedDate = DateTime.Now;
            centre.Account.Status = "INACTIVE";
            centre.Account.Role = "CENTER";
            centre.Rating = 5;
            await _unitOfWork.Account.CheckExistEmail(centre.Account.Email);
            await _unitOfWork.Account.CheckPhone(centre.Account.Phone);

            await _unitOfWork.MaintenanceCenter.Add(centre);
            await _unitOfWork.Account.Add(centre.Account);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseCenter>(centre);
        }

        public async Task<List<ResponseCenter>> GetAll()
        {
            return _mapper.Map<List<ResponseCenter>>(await _unitOfWork.MaintenanceCenter.GetAll());
        }

        public async Task<ResponseCenter> GetById(Guid id)
        {
            return _mapper.Map<ResponseCenter>(await _unitOfWork.MaintenanceCenter.GetById(id));
        }

        public async Task<TotalCountAndPrice> TotalGetListByMainInfor(Guid centerId)
        {
            var center = await _unitOfWork.InformationMaintenance.TotalGetListByCenter(centerId);
            return new TotalCountAndPrice
            {
                Count = center.Count,
                Price = center.TotalCost,
            };
        }

        public async Task<TotalCountAndPrice> TotalGetListByStatusAndStatusCostService(Guid centerId)
        {
            var center = await _unitOfWork.MaintenanceServiceCost.TotalGetListByStatusAndStatusCost(EnumStatus.ACTIVE.ToString(), EnumStatus.ACTIVE.ToString(), centerId);
            return new TotalCountAndPrice
            {
                Count = center.Count,
                Price = center.TotalCost,
            };
        }

        public async Task<TotalCountAndPrice> TotalGetListByStatusAndStatusCostSpartPart(Guid centerId)
        {
            var center = await _unitOfWork.SparePartsItemCost.TotalGetListByStatusAndCostStatus(EnumStatus.ACTIVE.ToString(), EnumStatus.ACTIVE.ToString(), centerId);
            return new TotalCountAndPrice
            {
                Count = center.Count,
                Price = center.TotalCost,
            };
        }

        public async Task<TotalCountAndPrice> TotalGetListByStatusPaidReceipt(Guid centerId)
        {
            var center = await _unitOfWork.ReceiptRepository.TotalGetListByStatusPaidCenter(centerId);
            return new TotalCountAndPrice
            {
                Count = center.Count,
                Price = center.TotalCost,
            };
        }

        public async Task<ResponseCenter> Update(Guid id, UpdateCenter center)
        {
            var center1 = await _unitOfWork.MaintenanceCenter.GetById(id);
            var update = _mapper.Map(center, center1);
            await _unitOfWork.MaintenanceCenter.Update(update);
            await _unitOfWork.Commit();

            return _mapper.Map<ResponseCenter>(update);

        }

        public async Task<ResponseCenter> UpdateStatus(Guid id, string status)
        {
            var center1 = await _unitOfWork.MaintenanceCenter.GetById(id);
            center1.Account.Status = status;
            await _unitOfWork.Account.Update(center1.Account);
            await _unitOfWork.Commit();

            return _mapper.Map<ResponseCenter>(center1);
        }
    }
}
