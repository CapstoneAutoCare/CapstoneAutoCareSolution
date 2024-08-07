﻿using AutoMapper;
using Domain.Entities;
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

        public async Task<ResponseSparePart> Update(Guid id, UpdateSparePart update)
        {
            var item = await _unitOfWork.SparePartsRepository.GetByID(id);
            item.SparePartName = update.SparePartName;
            item.SparePartDescription = update.SparePartDescription;
            item.SparePartType = update.SparePartType;
            item.OriginalPrice = update.OriginalPrice;
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
