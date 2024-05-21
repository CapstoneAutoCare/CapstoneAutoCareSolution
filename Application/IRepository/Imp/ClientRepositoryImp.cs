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
    public class ClientRepositoryImp : GenericRepositoryImp<Client>, IClientRepository
    {
        public ClientRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<Client>> GetAll()
        {
            return await _context.Set<Client>().Include(c => c.Account).ToListAsync();
        }

        public async Task<Client> GetByEmail(string email)
        {
            var client = await _context.Set<Client>().Include(c => c.Account)
                           .FirstOrDefaultAsync(c => c.Account.Email.ToLower().Equals(email.ToLower()));
            if (client == null)
            {
                throw new Exception("Not Found");
            }
            return client;
        }

        public async Task<Client> GetById(Guid id)
        {
            var client = await _context.Set<Client>()
                .Include(c => c.Account)
                .FirstOrDefaultAsync(c => c.ClientId == id);
            if (client == null)
            {
                throw new Exception("Not Found");
            }
            return client;
        }
    }
}
