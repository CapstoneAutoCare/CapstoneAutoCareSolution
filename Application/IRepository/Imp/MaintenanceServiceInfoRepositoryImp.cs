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
    public class MaintenanceServiceInfoRepositoryImp : GenericRepositoryImp<MaintenanceServiceInfo>, IMaintenanceServiceInfoRepository
    {
        public MaintenanceServiceInfoRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<MaintenanceServiceInfo>> GetAll()
        {
            return await _context.Set<MaintenanceServiceInfo>()
                            .Include(c => c.InformationMaintenance)
                            .Include(c => c.MaintenanceService)
                             .ToListAsync();
        }

        public async Task<MaintenanceServiceInfo> GetById(Guid id)
        {
            var msi = await _context.Set<MaintenanceServiceInfo>()
                                        .Include(c => c.InformationMaintenance)
                                        .Include(c => c.MaintenanceService)
                                        .FirstOrDefaultAsync(c => c.MaintenanceServiceInfoId == id);
            if (msi == null)
            {
                throw new Exception("not found");
            }
            return msi;
        }
    }
}
