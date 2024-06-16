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
    public class MaintenanceServiceCostRepositoryImp : GenericRepositoryImp<MaintenanceServiceCost>, IMaintenanceServiceCostRepository
    {
        public MaintenanceServiceCostRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<MaintenanceServiceCost>> GetAll()
        {
            return await _context.Set<MaintenanceServiceCost>()
                .Include(c => c.MaintenanceService)
                .ToListAsync();
        }

        public async Task<MaintenanceServiceCost> GetById(Guid id)
        {
            return await _context.Set<MaintenanceServiceCost>()
                .Include(c => c.MaintenanceService)
                .FirstOrDefaultAsync(c => c.MaintenanceServiceCostId == id);
        }

        public async Task<List<MaintenanceServiceCost>> GetListByStatusAndStatusCost(string status, string coststatus)
        {
            return await _context.Set<MaintenanceServiceCost>()
                            .Include(c => c.MaintenanceService)
                            .Where(c => c.Status.Equals(coststatus) && c.MaintenanceService.Status.Equals(status))
                            .ToListAsync();
        }
    }
}
