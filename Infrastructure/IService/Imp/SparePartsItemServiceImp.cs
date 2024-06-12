using AutoMapper;
using Domain.Entities;
using Infrastructure.Common.Request.Sparepart;
using Infrastructure.Common.Response.ResponseSparePart;
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
        public SparePartsItemServiceImp(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseSparePartsItem> Create(CreateSparePartsItem create)
        {
            var sparepart = _mapper.Map<SparePartsItem>(create);

            sparepart.CreatedDate = DateTime.Now;
            sparepart.Status = "ACTIVE";
            sparepart.Image = null;
            await _unitOfWork.MaintenanceCenter.GetById(sparepart.MaintenanceCenterId);

            if (sparepart.SparePartsId == null)
            {
                await _unitOfWork.SparePartsItem.Add(sparepart);
                await _unitOfWork.Commit();
            }
            else
            {
                await _unitOfWork.SparePartsRepository.GetByID(sparepart.SparePartsId);
                await _unitOfWork.SparePartsItem.Add(sparepart);
                await _unitOfWork.Commit();
            }
            return _mapper.Map<ResponseSparePartsItem>(sparepart);
        }


        public async Task<List<ResponseSparePartsItem>> GetAll()
        {
            return _mapper.Map<List<ResponseSparePartsItem>>(await _unitOfWork.SparePartsItem.GetAll());
        }

        public async Task<ResponseSparePartsItem> GetById(Guid id)
        {
            var spi = await _unitOfWork.SparePartsItem.GetById(id);
            return _mapper.Map<ResponseSparePartsItem>(spi);
        }

        public async Task<ResponseSparePartsItem> Update(Guid id, UpdateSparePartItem update)
        {
            var item = await _unitOfWork.SparePartsItem.GetById(id);
            //item.ActuralCost = update.ActuralCost;
            item.SparePartsId = update.SparePartsId;
            item.MaintenanceCenterId = update.MaintenanceCenterId;
            await _unitOfWork.SparePartsItem.Update(item);
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
    }
}
