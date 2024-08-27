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
    public class PackageCenterRepositoryImp : GenericRepositoryImp<CenterPackages>, IPackageCenterRepository
    {
        public PackageCenterRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<CenterPackages>> GetAll()
        {
            return await _context.Set<CenterPackages>().Include(c => c.Package).ToListAsync();
        }

        public async Task<CenterPackages> GetById(Guid id)
        {
            var i= await _context.Set<CenterPackages>().Include(c => c.Package).FirstOrDefaultAsync(c => c.CenterPackagesId == id);
            if (i == null)
            {
                throw new Exception("Không tìm thấy");
            }
            return i;
        }

        public async Task<List<CenterPackages>> GetListByCenterId(Guid id)
        {
            return await _context.Set<CenterPackages>().Include(c => c.Package).Where(c=>c.MaintenanceCenterId==id).ToListAsync();
        }

        public async Task<List<CenterPackages>> GetListByPackageId(Guid id)
        {
            return await _context.Set<CenterPackages>().Include(c => c.Package).Where(c => c.CenterPackagesId == id).ToListAsync();
        }
    }
}
