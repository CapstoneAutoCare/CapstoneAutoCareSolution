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
    public class StaffCareServiceImp : IStaffCareService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokensHandler _tokensHandler;

        public StaffCareServiceImp(IUnitOfWork unitOfWork, IMapper mapper, ITokensHandler tokensHandler)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokensHandler = tokensHandler;
        }

        public async Task<ResponseStaffCare> Create(CreateStaffCare create)
        {
            var email = _tokensHandler.ClaimsFromToken();
            var care = _mapper.Map<StaffCare>(create);
            var account = await _unitOfWork.Account.Profile(email);
            care.CenterId = account.MaintenanceCenter.MaintenanceCenterId;
            care.Account.CreatedDate = DateTime.Now;
            care.Account.Status = "ACTIVE";
            care.Account.Role = "TECHNICAN";
            care.StaffCareDescription = "null";
            await _unitOfWork.Account.Add(care.Account);
            await _unitOfWork.StaffCare.Add(care);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseStaffCare>(care);
        }

        public async Task<List<ResponseStaffCare>> GetAll()
        {
            return _mapper.Map<List<ResponseStaffCare>>(await _unitOfWork.StaffCare.GetAll());
        }

        public async Task<ResponseStaffCare> GetById(Guid id)
        {
            return _mapper.Map<ResponseStaffCare>(await _unitOfWork.StaffCare.GetById(id));
        }
    }
}
