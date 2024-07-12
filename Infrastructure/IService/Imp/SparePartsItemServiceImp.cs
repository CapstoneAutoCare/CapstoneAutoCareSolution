﻿using AutoMapper;
using Domain.Entities;
using Infrastructure.Common.Request.Sparepart;
using Infrastructure.Common.Response.ResponseCost;
using Infrastructure.Common.Response.ResponseServicesCare;
using Infrastructure.Common.Response.ResponseSparePart;
using Infrastructure.ISecurity;
using Infrastructure.IUnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infrastructure.IService.Imp
{
    public class SparePartsItemServiceImp : ISparePartsItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokensHandler _tokensHandler;

        public SparePartsItemServiceImp(IUnitOfWork unitOfWork, IMapper mapper, ITokensHandler tokensHandler)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokensHandler = tokensHandler;
        }

        public async Task<ResponseSparePartsItem> Create(CreateSparePartsItem create)
        {
            var email = _tokensHandler.ClaimsFromToken();
            var account = await _unitOfWork.Account.Profile(email);
            var sparepart = _mapper.Map<SparePartsItem>(create);
            sparepart.MaintenanceCenterId = account.MaintenanceCenter.MaintenanceCenterId;
            sparepart.CreatedDate = DateTime.Now;
            sparepart.Status = "ACTIVE";
            sparepart.Image = null;
            sparepart.Capacity = 50;
            await _unitOfWork.MaintenanceCenter.GetById(sparepart.MaintenanceCenterId);
            if (sparepart.SparePartsId == null)
            {
                await _unitOfWork.SparePartsItem.Add(sparepart);
                await _unitOfWork.Commit();
            }
            else
            {
               var item= await _unitOfWork.SparePartsRepository.GetByID(sparepart.SparePartsId);
                await _unitOfWork.SparePartsItem.Add(sparepart);
                await _unitOfWork.Commit();
            }
            return _mapper.Map<ResponseSparePartsItem>(sparepart);
        }


        public async Task<List<ResponseSparePartsItem>> GetAll()
        {
            return _mapper.Map<List<ResponseSparePartsItem>>(await _unitOfWork.SparePartsItem.GetAll());
        }

        public async Task<List<ResponseSparePartsItem>> GetListByCenter()
        {
            var email = _tokensHandler.ClaimsFromToken();
            var account = await _unitOfWork.Account.Profile(email);
            var list = await _unitOfWork.SparePartsItem.GetListByCenter(account.MaintenanceCenter.MaintenanceCenterId);
            return _mapper.Map<List<ResponseSparePartsItem>>(list);
        }
        public async Task<ResponseSparePartsItem> GetById(Guid id)
        {
            var spi = await _unitOfWork.SparePartsItem.GetById(id);
            return _mapper.Map<ResponseSparePartsItem>(spi);
        }

        public async Task<ResponseSparePartsItem> Update(Guid id, UpdateSparePartItem update)
        {
            var item = await _unitOfWork.SparePartsItem.GetById(id);

            var varcheck = _mapper.Map(update, item);
            await _unitOfWork.SparePartsItem.Update(varcheck);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseSparePartsItem>(item);

        }

        public async Task<ResponseSparePartsItem> UpdateStatus(Guid id, string status)
        {
            var item = await _unitOfWork.SparePartsItem.GetById(id);
            item.Status = status;
            await _unitOfWork.SparePartsItem.Update(item);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseSparePartsItem>(item);
        }

        public async Task Remove(Guid id)
        {
            var i = await _unitOfWork.SparePartsItem.GetById(id);
            await _unitOfWork.SparePartsItem.Remove(i);
            await _unitOfWork.Commit();
        }
    }
}
