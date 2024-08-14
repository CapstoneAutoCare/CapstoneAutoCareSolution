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
            return await _context.Set<SpareParts>()
                .Include(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                .OrderByDescending(p => p.CreatedDate)
                .ToListAsync();
        }

        public async Task<SpareParts> GetByID(Guid? id)
        {
            var sp = await _context.Set<SpareParts>()
                .Include(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                .OrderByDescending(p => p.CreatedDate)
                .FirstOrDefaultAsync(x => x.SparePartId.Equals(id));
            if (sp == null)
            {
                throw new Exception("Not Found");

            }
            return sp;
        }

        public async Task<List<SpareParts>> GetSpartPartNotSparePartItemId(Guid id)
        {
            var sparepartid = await _context.Set<SparePartsItem>()
                  .Include(c => c.SpareParts)
                  .Where(c => c.MaintenanceCenterId == id)
                  .Select(c => c.SparePartsId).ToListAsync();

            var sparepart = await _context.Set<SpareParts>()
               .Include(p => p.VehicleModel)
               .ThenInclude(c => c.VehiclesBrand)
                               .OrderByDescending(p => p.CreatedDate)
               .Where(c => !sparepartid.Contains(c.SparePartId)).ToListAsync();
            return sparepart;
        }
    }
}
