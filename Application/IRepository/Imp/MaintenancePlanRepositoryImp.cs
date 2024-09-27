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


        public async Task<MaintenancePlan> GetByIdWi(Guid? id)
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
            //var mcservice = await _context.Set<MaintenanceService>().Where(c=>c.MaintenanceCenterId == id)
            //    .Select(c=>c.ServiceCare.MaintananceSchedule.MaintenancePlanId)
            //    .ToListAsync();


            var plan = await _context.Set<MaintenancePlan>()
                .Include(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                .Include(c => c.MaintenanceSchedules)
                .ThenInclude(ms => ms.MaintenanceVehiclesDetails)
                .Where(mp => mp.MaintenanceSchedules
                    .Any(ms => ms.ServiceCares
                        .Any(mvd => mvd.MaintenanceServices.Any(c => c.MaintenanceCenterId == id))))

                .ToListAsync();

            return plan;
        }

        public async Task<List<MaintenancePlan>> GetListCenterIdAndVehicle(Guid centerId, Guid vehicleId)
        {


            var plan = await _context.Set<MaintenancePlan>()
        .Include(c => c.VehicleModel)
            .ThenInclude(c => c.VehiclesBrand)
        .Include(c => c.MaintenanceSchedules)
            .ThenInclude(ms => ms.MaintenanceVehiclesDetails)
        .Where(mp => mp.MaintenanceSchedules
            .Any(ms => ms.ServiceCares
                .Any(sc => sc.MaintenanceServices
                    .Any(c => c.MaintenanceCenterId == centerId))))
        .Where(mp => !mp.MaintenanceSchedules
            .Any(ms => ms.MaintenanceVehiclesDetails
                .Any(mvd => mvd.VehiclesId == vehicleId && mvd.MaintenanceCenterId == centerId)))

        .ToListAsync();

            return plan;

        }

        public async Task<List<MaintenancePlan>> GetListFilterCenterAndVehicle(Guid center, Guid vehicleId)
        {
            var mvd = await _context.Set<MaintenanceVehiclesDetail>()
                .Where(c => c.MaintenanceCenterId == center && c.VehiclesId == vehicleId)
                .OrderBy(c => c.MaintananceSchedule.MaintananceScheduleName)
                        .Select(c => c.MaintananceScheduleId)
                .ToListAsync();

            var plan = await _context.Set<MaintenancePlan>()
               .Where(mp => mp.MaintenanceSchedules.Any(ms => mvd.Contains(ms.MaintananceScheduleId)))
               .ToListAsync();

            return plan;
        }
    }
}
