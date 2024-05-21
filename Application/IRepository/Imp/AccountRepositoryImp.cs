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
                .Include(c => c.StaffCare)
                .Include(c=>c.Client)
                .Include(c=>c.Admin)
                .Include(c=>c.MaintenanceCenter)
                .Include(c=>c.StaffCare)
                .FirstOrDefaultAsync(c => c.Email.ToLower().Equals(email.ToLower()));
            if (account == null)
            {
                throw new Exception("Not Found");
            }
            return account;
        }
    }
}
