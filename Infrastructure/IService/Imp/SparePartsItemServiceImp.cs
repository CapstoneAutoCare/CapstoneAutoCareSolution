using AutoMapper;
using Domain.Entities;
using Infrastructure.Common.Request.Sparepart;
using Infrastructure.Common.Response.ReponseMaintenancePlan;
using Infrastructure.Common.Response.ReponseSparePart;
using Infrastructure.IUnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            await _unitOfWork.SparePartsRepository.GetByID(sparepart.SparePartsId);
            await _unitOfWork.MaintenanceCenter.GetById(sparepart.MaintenanceCenterId);

            sparepart.CreatedDate = DateTime.Now;
            sparepart.Status = "ACTIVE";

            await _unitOfWork.SparePartsItem.Add(sparepart);
            await _unitOfWork.Commit();

            return _mapper.Map<ResponseSparePartsItem>(sparepart);
        }

        public async Task<List<ResponseSparePartsItem>> GetAll()
        {
            return _mapper.Map<List<ResponseSparePartsItem>>(await _unitOfWork.SparePartsItem.GetAll());
        }

        public async Task<ResponseSparePartsItem> GetById(Guid id)
        {
            var spi = await _unitOfWork.SparePartsItem.GetByID(id);
            return _mapper.Map<ResponseSparePartsItem>(spi);
        }
    }
}
