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
    public class AdminRepositoryImp : GenericRepositoryImp<Admin>, IAdminRepository
    {
        public AdminRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public Task<Admin> GetById(Guid id)
        {
            var admin = _context.Set<Admin>().Include(c => c.Account).FirstOrDefaultAsync(c => c.AdminId.Equals(id));
            if (admin == null)
            {
                throw new Exception("Not Found");
            }
            return admin;
        }
    }
}
