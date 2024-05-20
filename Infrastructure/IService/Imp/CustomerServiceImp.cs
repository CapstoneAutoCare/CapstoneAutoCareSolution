using AutoMapper;
using Domain.Entities;
using Infrastructure.Common.Request.RequestAccount;
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

        public CustomerServiceImp(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Client> CreateCustomer(CreateClient create)
        {
            var client = _mapper.Map<Client>(create);
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
            return client;
        }
    }
}
