using AutoMapper;
using Domain.Entities;
using Infrastructure.Common.Request.MaintananceServices;
using Infrastructure.Common.Response.ReponseMaintenancePlan;
using Infrastructure.Common.Response.ReponseServicesCare;
using Infrastructure.IUnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class ServicesCaresSerivceImp : IServiceCaresService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ServicesCaresSerivceImp(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseServicesCare> Create(CreateServicesCare create)
        {
            var service = _mapper.Map<ServiceCare>(create);
            await _unitOfWork.MaintenancePlan.GetByID(service.MaintenancePlanId);

            service.CreatedDate = DateTime.Now;
            service.Status = "ACTIVE";

            await _unitOfWork.ServiceCare.Add(service);
            await _unitOfWork.Commit();

            return _mapper.Map<ResponseServicesCare>(service);
        }

        public async Task<List<ResponseServicesCare>> GetAll()
        {
            return _mapper.Map<List<ResponseServicesCare>>(await _unitOfWork.ServiceCare.GetAll());
        }

        public async Task<ResponseServicesCare> GetById(Guid id)
        {
            var maintanance_plan = await _unitOfWork.ServiceCare.GetByID(id);
            return _mapper.Map<ResponseServicesCare>(maintanance_plan);
        }

        public Task<ResponseServicesCare> Update(Guid id, UpdateServies update)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseServicesCare> UpdateStatus(Guid id, string status)
        {
            throw new NotImplementedException();
        }
    }
}
