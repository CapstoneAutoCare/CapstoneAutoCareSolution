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
    public class MaintenanceSparePartInfoRepositoryImp : GenericRepositoryImp<MaintenanceSparePartInfo>, IMaintenanceSparePartInfoRepository
    {
        public MaintenanceSparePartInfoRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<MaintenanceSparePartInfo>> GetAll()
        {
            return await _context.Set<MaintenanceSparePartInfo>()
                .Include(c => c.InformationMaintenance)
                .Include(c => c.SparePartsItem)
                 .ToListAsync();
        }

        public async Task<MaintenanceSparePartInfo> GetById(Guid id)
        {
            var spi = await _context.Set<MaintenanceSparePartInfo>()
                            .Include(c => c.SparePartsItem)
                            .Include(c => c.InformationMaintenance)
                            .FirstOrDefaultAsync(c => c.MaintenanceSparePartInfoId == id);
            if (spi == null)
            {
                throw new Exception("not found");
            }
            return spi;
        }
    }
}
