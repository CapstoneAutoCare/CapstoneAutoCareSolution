using AutoMapper;
using Domain.Entities;
using Domain.Enum;
using Infrastructure.Common.Request.RequestSparePartsItemCost;
using Infrastructure.Common.Response.ResponseCost;
using Infrastructure.Common.Response.ResponseHistoryStatus;
using Infrastructure.IUnitofWork;
using Infrastructure.IUnitofWork.Imp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class SparePartsItemCostServiceImp : ISparePartsItemCostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SparePartsItemCostServiceImp(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseSparePartsItemCost> Create(CreateSparePartsItemCost create)
        {
            var cost = _mapper.Map<SparePartsItemCost>(create);
            cost.Status = EnumStatus.INACTIVE.ToString();
            cost.DateTime = DateTime.UtcNow;
            await _unitOfWork.SparePartsItemCost.Add(cost);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseSparePartsItemCost>(cost);
        }

        public async Task<List<ResponseSparePartsItemCost>> GetAll()
        {
            return _mapper.Map<List<ResponseSparePartsItemCost>>(await _unitOfWork.SparePartsItemCost.GetAll());
        }

        public async Task<ResponseSparePartsItemCost> GetById(Guid id)
        {
            return _mapper.Map<ResponseSparePartsItemCost>(await _unitOfWork.SparePartsItemCost.GetById(id));
        }

        public async Task<List<ResponseSparePartsItemCost>> GetListByVIEWClient()
        {
            return _mapper.Map<List<ResponseSparePartsItemCost>>(
                await _unitOfWork.SparePartsItemCost.GetListByStatusAndCostStatus(EnumStatus.ACTIVE.ToString(), EnumStatus.ACTIVE.ToString()));
        }

        public async Task<ResponseSparePartsItemCost> UpdateStatus(Guid id, string status)
        {
            var cost = await _unitOfWork.SparePartsItemCost.GetById(id);
            cost.Status = status;
            await _unitOfWork.SparePartsItemCost.Update(cost);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseSparePartsItemCost>(cost);
        }
    }
}
