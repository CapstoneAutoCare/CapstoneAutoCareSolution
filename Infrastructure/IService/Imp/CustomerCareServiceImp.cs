using AutoMapper;
using Domain.Entities;
using Infrastructure.Common.Request.RequestAccount;
using Infrastructure.Common.Response.ClientResponse;
using Infrastructure.Common.Response.ResponseCustomerCare;
using Infrastructure.Common.Response.ResponseStaffCare;
using Infrastructure.ISecurity;
using Infrastructure.IUnitofWork;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infrastructure.IService.Imp
{
    public class CustomerCareServiceImp : ICustomerCareService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokensHandler _tokensHandler;
        private readonly IConfiguration _configuration;

        public CustomerCareServiceImp(IUnitOfWork unitOfWork, IMapper mapper, ITokensHandler tokensHandler,IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokensHandler = tokensHandler;
            _configuration = configuration;
        }

        public async Task<ResponseCustomerCare> CreateCustomerCare(CreateCustomerCare create)
        {
            var email = _tokensHandler.ClaimsFromToken();
            var care = _mapper.Map<CustomerCare>(create);
            var account = await _unitOfWork.Account.Profile(email);
            await _unitOfWork.Account.CheckExistEmail(care.Account.Email);
            await _unitOfWork.Account.CheckPhone(care.Account.Phone);

            care.CenterId = account.MaintenanceCenter.MaintenanceCenterId;
            care.Account.CreatedDate = DateTime.Now;
            care.Account.Status = "ACTIVE";
            care.Account.Role = "CUSTOMERCARE";
            care.CustomerCareDescription = "null";
            await _unitOfWork.Account.CheckPhone(care.Account.Phone);
            var adminEmail = _configuration["AccountSettings:AdminEmail"];
            var adminPassword = _configuration["AccountSettings:AdminPassword"];

            if (care.Account.Email == adminEmail && care.Account.Password == adminPassword)
            {
                throw new Exception("Không thể tạo tài khoản với thông tin đăng nhập của quản trị viên.");
            }
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

        public async Task<ResponseCustomerCare> Update(Guid id, UpdateCustomerCare center)
        {
            var center1 = await _unitOfWork.CustomerCare.GetById(id);
            var update = _mapper.Map(center, center1);

            var adminEmail = _configuration["AccountSettings:AdminEmail"];
            var adminPassword = _configuration["AccountSettings:AdminPassword"];

            if (update.Account.Email == adminEmail && update.Account.Password == adminPassword)
            {
                throw new Exception("Không thể cập nhật tài khoản với thông tin đăng nhập của quản trị viên.");
            }
            if (center.Phone != center1.Account.Phone)
            {
                await _unitOfWork.Account.CheckPhone(center.Phone);
            }
            update.Account.Phone = center.Phone;
            update.Account.Logo = center.Logo;
            await _unitOfWork.CustomerCare.Update(update);
            await _unitOfWork.Account.Update(update.Account);
            await _unitOfWork.Commit();

            return _mapper.Map<ResponseCustomerCare>(update);
        }
    }
}
