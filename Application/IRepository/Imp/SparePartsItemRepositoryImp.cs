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
    public class SparePartsItemRepositoryImp : GenericRepositoryImp<SparePartsItem>, ISparePartsItemRepository
    {
        public SparePartsItemRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<SparePartsItem>> GetAll()
        {
            return await _context.Set<SparePartsItem>().Include(p => p.SpareParts).ToListAsync();
        }

        public async Task<SparePartsItem> GetByID(Guid id)
        {
            var spi = await _context.Set<SparePartsItem>().Include(p => p.SpareParts).FirstOrDefaultAsync(x => x.Equals(id));
            if (spi == null)
            {
                throw new Exception("Not Found");

            }
            return spi;
        }
    }
}
