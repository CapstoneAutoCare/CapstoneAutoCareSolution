using AutoMapper;
using Domain.Entities;
using Infrastructure.Common.Request.RequestAccount;
using Infrastructure.Common.Response.ResponseCustomerCare;
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
    public class CustomerCareServiceImp : ICustomerCareService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokensHandler _tokensHandler;

        public CustomerCareServiceImp(IUnitOfWork unitOfWork, IMapper mapper, ITokensHandler tokensHandler)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokensHandler = tokensHandler;
        }

        public async Task<ResponseCustomerCare> CreateCustomerCare(CreateCustomerCare create)
        {
            var email = _tokensHandler.ClaimsFromToken();
            var care = _mapper.Map<CustomerCare>(create);
            var account = await _unitOfWork.Account.Profile(email);
            await _unitOfWork.Account.CheckExistEmail(care.Account.Email);
            care.CenterId = account.MaintenanceCenter.MaintenanceCenterId;
            care.Account.CreatedDate = DateTime.Now;
            care.Account.Status = "ACTIVE";
            care.Account.Role = "CUSTOMERCARE";
            care.CustomerCareDescription = "null";
            await _unitOfWork.Account.Add(care.Account);
            await _unitOfWork.CustomerCare.Add(care);
            await _unitOfWork.Commit();

            return _mapper.Map<ResponseCustomerCare>(care);
        }

        public async Task<List<ResponseCustomerCare>> GetAll()
        {
            return _mapper.Map<List<ResponseCustomerCare>>(await _unitOfWork.CustomerCare.GetAll());
        }

        public async Task<List<ResponseCustomerCare>> GetListByCenter(Guid centerId)
        {
            //var email = _tokensHandler.ClaimsFromToken();
            //var account = await _unitOfWork.Account.Profile(email);
            return _mapper.Map<List<ResponseCustomerCare>>(await _unitOfWork.CustomerCare.GetListByCenter(centerId));
        }

        public async Task<ResponseCustomerCare> GetCustomerCareById(Guid id)
        {
            return _mapper.Map<ResponseCustomerCare>(await _unitOfWork.CustomerCare.GetById(id));
        }
    }
}
