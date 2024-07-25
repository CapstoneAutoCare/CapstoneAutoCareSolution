using Application.IGenericRepository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        Task<Account> Login(string email, string password);
        Task<Account> Profile(string email);
        Task<Account> CheckExistEmail(string email);
        Task<Account> GetByClientId(Guid id);
    }
}
