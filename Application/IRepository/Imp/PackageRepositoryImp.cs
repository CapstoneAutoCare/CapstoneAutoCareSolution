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
    public class PackageRepositoryImp : GenericRepositoryImp<Package>, IPackageRepository
    {
        public PackageRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<Package>> GetAll()
        {
            return await _context.Set<Package>().ToListAsync();
        }

        public async Task<Package> GetById(Guid id)
        {
            var i =  await _context.Set<Package>().FirstOrDefaultAsync(c=>c.PackageId==id);
            if( i == null)
            {
                throw new Exception("Khong tim thay");
            }
            return i;
        }
    }
}
