using AutoMapper;
using Domain.Entities;
using Infrastructure.Common.Request.RequestAccount;
using Infrastructure.Common.Response.ResponseStaffCare;
using Infrastructure.ISecurity;
using Infrastructure.IUnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class TechicianServiceImp : ITechnicianService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokensHandler _tokensHandler;

        public TechicianServiceImp(IUnitOfWork unitOfWork, IMapper mapper, ITokensHandler tokensHandler)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokensHandler = tokensHandler;
        }

        public async Task<ResponseTechnician> Create(CreateTechnician create)
        {
            var email = _tokensHandler.ClaimsFromToken();
            var care = _mapper.Map<Technician>(create);
            var account = await _unitOfWork.Account.Profile(email);
            await _unitOfWork.Account.CheckExistEmail(care.Account.Email);
            care.CenterId = account.MaintenanceCenter.MaintenanceCenterId;
            care.Account.CreatedDate = DateTime.Now;
            care.Account.Status = "ACTIVE";
            care.Account.Role = "TECHNICAN";
            care.TechnicianDescription = "null";
            await _unitOfWork.Account.Add(care.Account);
            await _unitOfWork.Techician.Add(care);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseTechnician>(care);
        }

        public async Task<List<ResponseTechnician>> GetAll()
        {
            return _mapper.Map<List<ResponseTechnician>>(await _unitOfWork.Techician.GetAll());
        }

        public async Task<ResponseTechnician> GetById(Guid id)
        {
            return _mapper.Map<ResponseTechnician>(await _unitOfWork.Techician.GetById(id));
        }
    }
}
