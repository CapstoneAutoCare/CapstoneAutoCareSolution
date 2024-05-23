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
    public class SparePartsRepositoryImp : GenericRepositoryImp<SpareParts>, ISparePartsRepository
    {
        public SparePartsRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<SpareParts>> GetAll()
        {
            return await _context.Set<SpareParts>().Include(p => p.MaintenancePlan).ToListAsync();
        }

        public async Task<SpareParts> GetByID(Guid id)
        {
            var sp = await _context.Set<SpareParts>().Include(p => p.MaintenancePlan).FirstOrDefaultAsync(x => x.SparePartId.Equals(id));
            if (sp == null)
            {
                throw new Exception("Not Found");

            }
            return sp;
        }
    }
}
