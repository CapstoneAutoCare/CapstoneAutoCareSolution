using Domain.Entities;
using Infrastructure.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface IAccountService
    {
        Task<AuthenResponseMessToken> Login(string email, string password);
        Task<JsonNode> Profile();
    }
}
