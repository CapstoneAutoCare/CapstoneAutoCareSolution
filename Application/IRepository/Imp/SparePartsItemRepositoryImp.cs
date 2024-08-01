using Application.IGenericRepository.Imp;
using Domain.Entities;
using Domain.Enum;
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
            return await _context.Set<SparePartsItem>()
                .Include(c => c.MaintenanceCenter)
                .Include(c => c.SparePartsItemCost)
                .Include(p => p.SpareParts)
                            .ThenInclude(c => c.MaintananceSchedule)
                            .ThenInclude(c => c.VehicleModel)
                            .ThenInclude(c => c.VehiclesBrand)
                .OrderByDescending(c => c.CreatedDate)
                .ToListAsync();
        }

        public async Task<SparePartsItem> GetById(Guid? id)
        {
            var spi = await _context.Set<SparePartsItem>()
                .Include(c => c.SparePartsItemCost)
                .Include(c => c.MaintenanceCenter)
                .Include(c => c.SpareParts)
                            .ThenInclude(c => c.MaintananceSchedule)
                            .ThenInclude(c => c.VehicleModel)
                            .ThenInclude(c => c.VehiclesBrand)
                .OrderByDescending(c => c.CreatedDate)
                .FirstOrDefaultAsync(x => x.SparePartsItemtId.Equals(id));
            if (spi == null)
            {
                throw new Exception("Not Found");

            }
            return spi;
        }

        public async Task<SparePartsItem> GetByStatusAndCostActive(Guid? id)
        {
            var spi = await _context.Set<SparePartsItem>()
                            .Include(c => c.MaintenanceCenter)
                            .Include(c => c.SparePartsItemCost)
                            .Include(c => c.SpareParts)
                            .ThenInclude(c => c.MaintananceSchedule)
                            .ThenInclude(c => c.VehicleModel)
                            .ThenInclude(c => c.VehiclesBrand)
                            .OrderByDescending(c => c.CreatedDate)
                            .FirstOrDefaultAsync(x => x.SparePartsItemtId.Equals(id)
                            && x.Status.Equals(EnumStatus.ACTIVE.ToString())
                            && x.SparePartsItemCost.Select(c => c.Status.Equals(EnumStatus.ACTIVE.ToString())).LastOrDefault());
            if (spi == null)
            {
                throw new Exception("Not Found");

            }
            return spi;
        }

        public async Task<List<SparePartsItem>> GetListByCenter(Guid center)
        {
            return await _context.Set<SparePartsItem>()
                            .Include(c => c.MaintenanceCenter)
                            .Include(c => c.SparePartsItemCost)
                            .Include(c => c.SpareParts)
                            .ThenInclude(c => c.MaintananceSchedule)
                            .ThenInclude(c => c.VehicleModel)
                            .ThenInclude(c => c.VehiclesBrand)
                            .OrderByDescending(c => c.CreatedDate)
                            .Include(p => p.SpareParts).Where(c => c.MaintenanceCenterId == center)
                            .ToListAsync();
        }






    }
}
