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
    public class ServiceCareCostRepositoryImp : GenericRepositoryImp<MaintenanceService>, IMaintenanceServiceRepository
    {
        public ServiceCareCostRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<MaintenanceService>> GetAll()
        {
            return await _context.Set<MaintenanceService>()
                .Include(c => c.MaintenanceCenter)
                .Include(p => p.ServiceCare).ToListAsync();
        }

        public async Task<MaintenanceService> GetById(Guid? id)
        {
            var ms = await _context.Set<MaintenanceService>()
                .Include(c => c.MaintenanceCenter)
                .Include(p => p.ServiceCare)
                .FirstOrDefaultAsync(x => x.MaintenanceServiceId.Equals(id));
            if (ms == null)
            {
                throw new Exception("Not Found");

            }
            return ms;
        }

        public async Task<List<MaintenanceService>> GetListByCenter(Guid center)
        {
            return await _context.Set<MaintenanceService>()
                            .Include(c => c.MaintenanceCenter)
                            .Include(p => p.ServiceCare).Where(c => c.MaintenanceCenterId == center)
                            .ToListAsync();
        }
    }
}
