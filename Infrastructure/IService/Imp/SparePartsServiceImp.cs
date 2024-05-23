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
    public class SparePartsServiceImp : ISparePartsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SparePartsServiceImp(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public Task<ResponseSparePart> Create(CreateSpareParts create)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResponseSparePart>> GetAll()
        {
            return _mapper.Map<List<ResponseSparePart>>(await _unitOfWork.SparePartsRepository.GetAll());
        }

        public async Task<ResponseSparePart> GetById(Guid id)
        {
            var maintanance_plan = await _unitOfWork.SparePartsRepository.GetByID(id);
            return _mapper.Map<ResponseSparePart>(maintanance_plan);
        }
    }
}
