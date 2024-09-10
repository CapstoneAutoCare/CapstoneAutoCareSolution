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
    public class MaintenancePlanRepositoryImp : GenericRepositoryImp<MaintenancePlan>, IMaintenancePlanRepository
    {
        public MaintenancePlanRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<MaintenancePlan>> GetAll()
        {
            return await _context.Set<MaintenancePlan>().Include(c => c.VehicleModel).ThenInclude(c => c.VehiclesBrand)
                                .Include(c => c.MaintenanceSchedules).ToListAsync();
        }

        public async Task<MaintenancePlan> GetById(Guid id)
        {
            var plan = await _context.Set<MaintenancePlan>()
                .Include(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                .Include(c => c.MaintenanceSchedules)
                .FirstOrDefaultAsync(c => c.MaintenancePlanId == id);
            if (plan == null)
            {
                throw new Exception("KHONG TIM THAY ");
            }
            return plan;
        }

        public async Task<List<MaintenancePlan>> GetListCenterId(Guid id)
        {
            //var detail = await _context.Set<MaintenanceVehiclesDetail>()
            //    .Include(c => c.MaintenanceCenter)
            //    .ThenInclude(c => c.Account)
            //                    .Include(c => c.MaintananceSchedule).ThenInclude(c => c.MaintenancePlan)
            //                    .Where(c => c.MaintenanceCenterId == id).Select(c => c.MaintananceScheduleId).ToListAsync();

            var plans = _context.MaintenancePlans
                 .Include(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                .Include(c => c.MaintenanceSchedules)
              .Where(mp => mp.MaintenanceSchedules.Any(ms => ms.MaintenanceVehiclesDetails
                  .Any(mvd => mvd.MaintenanceCenterId == id)))
              .ToList();
            return plans;
        }
    }
}
