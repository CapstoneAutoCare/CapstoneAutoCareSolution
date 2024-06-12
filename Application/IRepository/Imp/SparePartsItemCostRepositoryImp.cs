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
    public class SparePartsItemCostRepositoryImp : GenericRepositoryImp<SparePartsItemCost>, ISparePartsItemCostRepository
    {
        public SparePartsItemCostRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<SparePartsItemCost>> GetAll()
        {
            return await _context.Set<SparePartsItemCost>().ToListAsync();
        }

        public async Task<SparePartsItemCost> GetById(Guid id)
        {
            return await _context.Set<SparePartsItemCost>().FirstOrDefaultAsync(c => c.SparePartsItemCostId == id);
        }
    }
}
