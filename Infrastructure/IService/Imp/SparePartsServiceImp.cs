using AutoMapper;
using Domain.Entities;
using Domain.Enum;
using Infrastructure.Common.Request.Sparepart;
using Infrastructure.Common.Response.ResponseSparePart;
using Infrastructure.ISecurity;
using Infrastructure.IUnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class SparePartsServiceImp : ISparePartsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokensHandler _tokensHandler;

        public SparePartsServiceImp(IUnitOfWork unitOfWork, IMapper mapper, ITokensHandler tokensHandler)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokensHandler = tokensHandler;
        }

        public async Task<ResponseSparePart> Create(CreateSpareParts create)
        {

            var sparepart = _mapper.Map<SpareParts>(create);
            await _unitOfWork.VehicleModel.GetById(sparepart.VehicleModelId);

            sparepart.CreatedDate = DateTime.Now;
            sparepart.Status = "ACTIVE";
            await _unitOfWork.SparePartsRepository.Add(sparepart);
            await _unitOfWork.Commit();

            return _mapper.Map<ResponseSparePart>(sparepart);
        }

        public async Task<List<ResponseSparePart>> GetAll()
        {
            return _mapper.Map<List<ResponseSparePart>>(await _unitOfWork.SparePartsRepository.GetAll());
        }

        public async Task<ResponseSparePart> GetById(Guid id)
        {
            var sparepart = await _unitOfWork.SparePartsRepository.GetByID(id);
            return _mapper.Map<ResponseSparePart>(sparepart);
        }

        public async Task<List<ResponseSparePart>> GetSpartPartNotSparePartItemId(Guid id)
        {
            return _mapper.Map<List<ResponseSparePart>>(await _unitOfWork.SparePartsRepository.GetSpartPartNotSparePartItemId(id));
        }

        public async Task<ResponseSparePart> Update(Guid id, UpdateSparePart update)
        {
            var item = await _unitOfWork.SparePartsRepository.GetByID(id);
            item.SparePartName = update.SparePartName;
            item.SparePartDescription = update.SparePartDescription;
            item.SparePartType = update.SparePartType;
            item.Status = update.Status;
            item.Image=update.Image;
            //if (item.OriginalPrice != update.OriginalPrice)
            //{
            item.OriginalPrice = update.OriginalPrice;
            var ms = await _unitOfWork.SparePartsItem.GetListBySparepartId(item.SparePartId);
            //if (ms != null)
            //{
            foreach (var m in ms)
            {
                SparePartsItemCost cost = new SparePartsItemCost
                {
                    ActuralCost = item.OriginalPrice,
                    DateTime = DateTime.Now,
                    SparePartsItemId = m.SparePartsItemId,
                    Note = "Giá mới được cập nhật từ nhà cung cấp",
                    Status = EnumStatus.INACTIVE.ToString(),
                    SparePartsItemCostId = Guid.NewGuid(),
                };
                await _unitOfWork.SparePartsItemCost.Add(cost);
            }
            //}
            //}

            await _unitOfWork.SparePartsRepository.Update(item);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseSparePart>(item);
        }

        public async Task<ResponseSparePart> UpdateStatus(Guid id, string status)
        {
            var item = await _unitOfWork.SparePartsRepository.GetByID(id);
            item.Status = status;
            await _unitOfWork.SparePartsRepository.Update(item);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseSparePart>(item);
        }
    }
}
