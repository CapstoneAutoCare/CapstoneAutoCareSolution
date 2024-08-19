using AutoMapper;
using Domain.Entities;
using Infrastructure.Common.Request.RequestAccount;
using Infrastructure.Common.Response.ClientResponse;
using Infrastructure.Common.Response.ReponseVehicleModel;
using Infrastructure.ISecurity;
using Infrastructure.IUnitofWork;
using Infrastructure.IUnitofWork.Imp;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class CustomerServiceImp : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokensHandler _tokensHandler;
        private readonly IConfiguration _configuration;
        public CustomerServiceImp(IUnitOfWork unitOfWork, IMapper mapper, ITokensHandler tokensHandler, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokensHandler = tokensHandler;
            _configuration = configuration;
        }

        public async Task<ResponseClient> CreateCustomer(CreateClient create)
        {
            var client = _mapper.Map<Client>(create);
            await _unitOfWork.Account.CheckExistEmail(client.Account.Email);
            await _unitOfWork.Account.CheckPhone(client.Account.Phone);

            client.Account.Status = "ACTIVE";
            client.Account.Role = "CUSTOMER";
            client.Account.CreatedDate = DateTime.Now;
            var adminEmail = _configuration["AccountSettings:AdminEmail"];
            var adminPassword = _configuration["AccountSettings:AdminPassword"];

            if (client.Account.Email == adminEmail && client.Account.Password == adminPassword)
            {
                throw new Exception("Không thể tạo tài khoản với thông tin đăng nhập của quản trị viên.");
            }

            await _unitOfWork.Account.Add(client.Account);
            await _unitOfWork.Client.Add(client);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseClient>(client);
        }

        public async Task<List<ResponseClient>> GetAll()
        {
            return _mapper.Map<List<ResponseClient>>(await _unitOfWork.Client.GetAll());
        }

        public async Task<ResponseClient> GetById(Guid id)
        {
            var client = await _unitOfWork.Client.GetById(id);
            return _mapper.Map<ResponseClient>(client);
        }

        public async Task<ResponseClient> Update(Guid id, UpdateClient updateClient)
        {
            var center1 = await _unitOfWork.Client.GetById(id);

            var update = _mapper.Map(updateClient, center1);
            if (updateClient.Phone != center1.Account.Phone)
            {
                await _unitOfWork.Account.CheckPhone(updateClient.Phone);
            }
            var adminEmail = _configuration["AccountSettings:AdminEmail"];
            var adminPassword = _configuration["AccountSettings:AdminPassword"];

            if (center1.Account.Email == adminEmail && center1.Account.Password == adminPassword)
            {
                throw new Exception("Không thể tạo tài khoản với thông tin đăng nhập của quản trị viên.");
            }
            update.Account.Phone = updateClient.Phone;
            update.Account.Logo = updateClient.Logo;
            await _unitOfWork.Client.Update(update);
            await _unitOfWork.Account.Update(update.Account);
            await _unitOfWork.Commit();

            return _mapper.Map<ResponseClient>(update);
        }
    }
}
