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
            






            var plan = await _context.Set<MaintenancePlan>()
                .Include(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                .Include(c => c.MaintenanceSchedules)
                .ThenInclude(ms => ms.MaintenanceVehiclesDetails) // Include the MaintenanceVehiclesDetails
                .Where(mp => mp.MaintenanceSchedules
                    .Any(ms => ms.MaintenanceVehiclesDetails
                        .Any(mvd => mvd.MaintenanceCenterId == id))) // Use Any instead of Select
                .ToListAsync();

            return plan;
        }
    }
}
