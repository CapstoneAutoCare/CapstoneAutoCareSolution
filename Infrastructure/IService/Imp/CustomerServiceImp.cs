using AutoMapper;
using Domain.Entities;
using Infrastructure.Common.Request.RequestAccount;
using Infrastructure.Common.Response.ClientResponse;
using Infrastructure.Common.Response.ReponseVehicleModel;
using Infrastructure.ISecurity;
using Infrastructure.IUnitofWork;
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

        public CustomerServiceImp(IUnitOfWork unitOfWork, IMapper mapper, ITokensHandler tokensHandler)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokensHandler = tokensHandler;
        }

        public async Task<ResponseClient> CreateCustomer(CreateClient create)
        {
            var client = _mapper.Map<Client>(create);
            await _unitOfWork.Account.CheckExistEmail(client.Account.Email);

            client.Account.Status = "ACTIVE";
            client.Account.Role = "CUSTOMER";
            client.Account.CreatedDate = DateTime.Now;
            //Client client1 = new Client
            //{
            //    Address= create.Address,
            //    Birthday= create.Birthday,
            //    FirstName= create.FirstName,
            //    LastName= create.LastName,

            //    Account = new Account
            //    {
            //        CreatedDate = DateTime.Now,
            //        Email= create.Email,
            //        Gender= create.Gender,
            //        Logo= create.Logo,
            //        Password= create.Password,
            //        Role = "CUSTMOMER",
            //        Phone= create.Phone,
            //        Status ="ACTIVE"
            //    }
            //};

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
            update.Account.Logo = updateClient.Logo;
            await _unitOfWork.Client.Update(update);
            await _unitOfWork.Commit();

            return _mapper.Map<ResponseClient>(update); 
        }
    }
}
