﻿using AutoMapper;
using Domain.Entities;
using Domain.Enum;
using Infrastructure.Common.Request.RequestSparepart;
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

            var item = await _unitOfWork.SparePartsRepository.GetByID(sparepart.SparePartsId);
            await _unitOfWork.SparePartsItem.Add(sparepart);

            SparePartsItemCost cost = new SparePartsItemCost
            {
                ActuralCost = item.OriginalPrice,
                Status = EnumStatus.ACTIVE.ToString(),
                Note = "Đồng bộ với nhà cung cấp",
                SparePartsItemId = sparepart.SparePartsItemId,
                SparePartsItemCostId = Guid.NewGuid(),

            };
            cost.DateTime = DateTime.Now;
            await _unitOfWork.SparePartsItemCost.Add(cost);
            await _unitOfWork.Commit();
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

        public async Task<List<ResponseSparePartsItem>> GetListByCenterId(Guid id)
        {
            var list = await _unitOfWork.SparePartsItem.GetListByCenter(id);
            return _mapper.Map<List<ResponseSparePartsItem>>(list);
        }

        public async Task<List<ResponseSparePartsItem>> CreateList(CreateListSparePartItem create)
        {
            var email = _tokensHandler.ClaimsFromToken();
            var account = await _unitOfWork.Account.Profile(email);
            List<SparePartsItem> list = new List<SparePartsItem>();

            if (create.SparePartsId == null || !create.SparePartsId.Any())
            {
                throw new Exception("Danh sách phụ tùng bị trống.");
            }

            foreach (var sparepart in create.SparePartsId)
            {
                var spare = await _unitOfWork.SparePartsRepository.GetByID(sparepart);
                SparePartsItem item = new SparePartsItem
                {
                    CreatedDate = DateTime.Now,
                    Image = spare.Image,
                    SparePartsId = sparepart,
                    Capacity = 0,
                    MaintenanceCenterId = account.MaintenanceCenter.MaintenanceCenterId,
                    SparePartsItemName = spare.SparePartName,
                    SparePartsItemId = Guid.NewGuid(),
                    Status = EnumStatus.ACTIVE.ToString(),
                    SparePartsItemType=spare.SparePartType,
                    
                };
                await _unitOfWork.SparePartsItem.Add(item);
                list.Add(item);

                SparePartsItemCost cost = new SparePartsItemCost
                {
                    ActuralCost = spare.OriginalPrice,
                    Status = EnumStatus.ACTIVE.ToString(),
                    Note = "Đồng bộ với nhà cung cấp",
                    SparePartsItemId = item.SparePartsItemId,
                    SparePartsItemCostId = Guid.NewGuid(),
                };
                cost.DateTime = DateTime.Now;
                await _unitOfWork.SparePartsItemCost.Add(cost);
            }

            await _unitOfWork.Commit();
            return _mapper.Map<List<ResponseSparePartsItem>>(list);
        }

    }
}
