﻿using Domain.Entities;
using Infrastructure.Common.Request.MaintenanceSchedule;
using Infrastructure.Common.Request.RequestSparepart;
using Infrastructure.Common.Request.Sparepart;
using Infrastructure.Common.Response.ResponseCost;
using Infrastructure.Common.Response.ResponseServicesCare;
using Infrastructure.Common.Response.ResponseSparePart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface ISparePartsItemService
    {
        Task<List<ResponseSparePartsItem>> GetAll();
        Task<List<ResponseSparePartsItem>> GetListByCenter();
        Task<List<ResponseSparePartsItem>> GetListByCenterId(Guid id);

        Task<ResponseSparePartsItem> GetById(Guid id);
        Task<ResponseSparePartsItem> Create(CreateSparePartsItem create);
        Task<List<ResponseSparePartsItem>> CreateList(CreateListSparePartItem create);
        Task<ResponseSparePartsItem> Update(Guid id, UpdateSparePartItem update);
        Task<ResponseSparePartsItem> UpdateStatus(Guid id, string status);

        Task Remove (Guid id);
    }
}
