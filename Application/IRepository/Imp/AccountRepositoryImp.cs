using Application.IGenericRepository.Imp;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository.Imp
{
    public class AccountRepositoryImp : GenericRepositoryImp<Account>, IAccountRepository
    {
        public AccountRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<Account> CheckExistEmail(string email)
        {
            var check = await _context.Set<Account>()
                .FirstOrDefaultAsync(c => c.Email.ToLower().Equals(email.ToLower()));
            if (check != null)
            {
                throw new Exception("Exist Email Here");
            }
            return check;
        }

        public async Task<Account> CheckPhone(string phone)
        {
            var check = await _context.Set<Account>()
                           .SingleOrDefaultAsync(c => c.Phone == phone);
            if (check != null)
            {
                throw new Exception("Phone existed");
            }
            return check;
        }

        public async Task<Account> GetByClientId(Guid id)
        {
            var check = await _context.Set<Account>()
                .FirstOrDefaultAsync(c => c.Client.ClientId == id);
            if (check == null)
            {
                throw new Exception("Null Found");
            }
            return check;
        }

        public async Task<Account> Login(string email, string password)
        {
            var check = await _context.Set<Account>().FirstOrDefaultAsync(c => c.Email.ToLower().Equals(email) && c.Password.ToLower().Equals(password));
            if (check == null)
            {
                throw new Exception("Sai password");
            }
            return check;
        }

        public async Task<Account> Profile(string email)
        {
            var account = await _context.Set<Account>()
                .Include(c => c.Technician)
                .Include(c => c.Client)
                .Include(c => c.Admin)
                .Include(c => c.MaintenanceCenter)
                .Include(c => c.CustomerCare)
                .FirstOrDefaultAsync(c => c.Email.ToLower().Equals(email.ToLower()));
            if (account == null)
            {
                throw new Exception("Not Found");
            }
            return account;
        }
    }
}
