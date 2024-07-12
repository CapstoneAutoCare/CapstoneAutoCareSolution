using AutoMapper;
using Infrastructure.Common.Request.RequestAccount;
using Infrastructure.Common.Response;
using Infrastructure.Common.Response.ClientResponse;
using Infrastructure.Common.Response.ReponseVehicleModel;
using Infrastructure.Common.Response.ResponseAdmin;
using Infrastructure.Common.Response.ResponseCustomerCare;
using Infrastructure.Common.Response.ResponseStaffCare;
using Infrastructure.ISecurity;
using Infrastructure.IUnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class AccountServiceImp : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokensHandler _tokensHandler;

        public AccountServiceImp(IUnitOfWork unitOfWork, IMapper mapper, ITokensHandler tokensHandler)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokensHandler = tokensHandler;
        }

        public async Task<JsonNode> ChangePassword(ChangePasswordAccount changePasswordAccount)
        {
            var email = _tokensHandler.ClaimsFromToken();
            var account = await _unitOfWork.Account.Profile(email);
            if (account.Password != changePasswordAccount.OldPassword)
            {
                throw new Exception("Error Password");
            }
            account.Password = changePasswordAccount.NewPassword;
            if (changePasswordAccount.NewPassword != changePasswordAccount.ConfirmPassword)
            {
                throw new Exception("Error Duplicate Password");
            }
            await _unitOfWork.Account.Update(account);
            JsonNode resultNode = null;
            await _unitOfWork.Commit();
            if (account.Role.Equals("ADMIN"))
            {
                var responseAdmin = _mapper.Map<ResponseAdmin>(account.Admin);
                resultNode = ConvertToJsonNode(responseAdmin);
            }
            else if (account.Role.Equals("CUSTOMER"))
            {
                var responseClient = _mapper.Map<ResponseClient>(account.Client);
                resultNode = ConvertToJsonNode(responseClient);
            }
            else if (account.Role.Equals("CUSTOMERCARE"))
            {
                var responseClient = _mapper.Map<ResponseCustomerCare>(account.CustomerCare);
                resultNode = ConvertToJsonNode(responseClient);
            }
            else if (account.Role.Equals("TECHNICIAN"))
            {
                var responseClient = _mapper.Map<ResponseTechnician>(account.Technician);
                resultNode = ConvertToJsonNode(responseClient);
            }
            else if (account.Role.Equals("CENTER"))
            {
                var responseCenter = _mapper.Map<ResponseCenter>(account.MaintenanceCenter);
                resultNode = ConvertToJsonNode(responseCenter);
            }
            return resultNode;
        }

        public async Task<AuthenResponseMessToken> Login(string email, string password)
        {
            var account = await _unitOfWork.Account.Login(email, password);
            var token = _tokensHandler.CreateAccessToken(account);

            return _mapper.Map<AuthenResponseMessToken>(token);
        }

        public async Task<JsonNode> Profile()
        {
            var email = _tokensHandler.ClaimsFromToken();
            var account = await _unitOfWork.Account.Profile(email);

            JsonNode resultNode = null;

            if (account.Role.Equals("ADMIN"))
            {
                var responseAdmin = _mapper.Map<ResponseAdmin>(account.Admin);
                resultNode = ConvertToJsonNode(responseAdmin);
            }
            else if (account.Role.Equals("CUSTOMER"))
            {
                var responseClient = _mapper.Map<ResponseClient>(account.Client);
                resultNode = ConvertToJsonNode(responseClient);
            }
            else if (account.Role.Equals("CUSTOMERCARE"))
            {
                var responseClient = _mapper.Map<ResponseCustomerCare>(account.CustomerCare);
                resultNode = ConvertToJsonNode(responseClient);
            }
            else if (account.Role.Equals("TECHNICIAN"))
            {
                var responseClient = _mapper.Map<ResponseTechnician>(account.Technician);
                resultNode = ConvertToJsonNode(responseClient);
            }
            else if (account.Role.Equals("CENTER"))
            {
                var responseCenter = _mapper.Map<ResponseCenter>(account.MaintenanceCenter);
                resultNode = ConvertToJsonNode(responseCenter);
            }
            return resultNode;
        }

        private JsonNode ConvertToJsonNode<T>(T obj)
        {
            var jsonElement = JsonSerializer.SerializeToElement(obj);
            return JsonNode.Parse(jsonElement.GetRawText());
        }
    }
}
