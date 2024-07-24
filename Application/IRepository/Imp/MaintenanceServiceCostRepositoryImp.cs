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

        public async Task<MaintenanceServiceCost> GetById(Guid? id)
        {
            return await _context.Set<MaintenanceServiceCost>()
                .Include(c => c.MaintenanceService)
                .Include(c => c.MaintenanceServiceInfos)
                .FirstOrDefaultAsync(c => c.MaintenanceServiceCostId == id);
        }

        public async Task<MaintenanceServiceCost> GetByIdMaintenanceServiceActive(string status, string cost, Guid id)
        {
            var msc = await _context.Set<MaintenanceServiceCost>()
                        .Include(c => c.MaintenanceService)
                        .Include(c => c.MaintenanceServiceInfos)
                        .Where(c => c.MaintenanceServiceId == id && c.Status.Equals(cost) && c.MaintenanceService.Status.Equals(status))
                        .OrderByDescending(c => c.DateTime)
                        .FirstOrDefaultAsync();
            return msc;
        }

        public async Task<List<MaintenanceServiceCost>> GetListByDifMaintenanceServiceAndInforId(string status, string cost, Guid centerId, Guid informationId)
        {
            var query = _context.Set<MaintenanceServiceCost>()
                                .Include(c => c.MaintenanceService)
                                .Where(c => c.MaintenanceService.MaintenanceCenterId == centerId
                                         && c.Status.Equals(cost)
                                         && c.MaintenanceService.Status.Equals(status)
                                         && !_context.Set<MaintenanceServiceInfo>()
                                                     .Any(m => m.MaintenanceServiceCost.MaintenanceServiceId == c.MaintenanceServiceId
                                                            && m.InformationMaintenanceId == informationId))
                                .OrderByDescending(c => c.DateTime);

            var groupedResult = await query
                                      .GroupBy(c => c.MaintenanceServiceId)
                                      .Select(g => g.OrderByDescending(c => c.DateTime).FirstOrDefault())
                                      .ToListAsync();

            return groupedResult;
        }

        public async Task<List<MaintenanceServiceCost>> GetListByStatusAndStatusCost(string status, string coststatus, Guid centerId)
        {
            var query = _context.Set<MaintenanceServiceCost>()
                                .Include(c => c.MaintenanceService)
                                .Include(c => c.MaintenanceServiceInfos)
                                .Where(c => c.MaintenanceService.MaintenanceCenterId == centerId && c.Status.Equals(coststatus) && c.MaintenanceService.Status.Equals(status));

            var groupedResult = await query
                                      .GroupBy(c => c.MaintenanceServiceId)
                                      .Select(g => g.OrderByDescending(c => c.DateTime)
                                                    .FirstOrDefault())
                                      .ToListAsync();

            return groupedResult;
        }

    }
}
