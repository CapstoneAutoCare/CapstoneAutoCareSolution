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
    public class MaintananceScheduleRepositoryImp : GenericRepositoryImp<MaintananceSchedule>, IMaintananceScheduleRepository
    {
        public MaintananceScheduleRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<MaintananceSchedule>> GetAll()
        {
            return await _context.Set<MaintananceSchedule>()
                .Include(c => c.MaintenancePlan)
                .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                .ToListAsync();
        }

        public async Task<MaintananceSchedule> GetByID(Guid? id)
        {
            var maintanance_schedule = await _context.Set<MaintananceSchedule>().Include(c => c.MaintenancePlan).ThenInclude(a => a.VehicleModel).ThenInclude(c => c.VehiclesBrand)
                .FirstOrDefaultAsync(c => c.MaintananceScheduleId == id);
            if (maintanance_schedule == null)
            {
                throw new Exception("Not Found");
            }
            return maintanance_schedule;
        }

        public async Task<List<MaintananceSchedule>> GetListPackageByCenterId(Guid id)
        {
            var maintenanceServices = await _context.Set<MaintenanceService>()
                .Include(c => c.VehicleModel)
                    .ThenInclude(c => c.VehiclesBrand)
                .Include(ms => ms.ServiceCare)
                    .ThenInclude(sc => sc.MaintananceSchedule)
                    .ThenInclude(c => c.MaintenancePlan)
                .Where(ms => ms.MaintenanceCenterId == id)
                .ToListAsync();

            var maintananceSchedules = maintenanceServices

                .Where(ms => ms.ServiceCare != null)

                .Select(ms => ms.ServiceCare.MaintananceSchedule)

                .Distinct()
                .ToList();

            return maintananceSchedules;
        }

        public async Task<List<MaintananceSchedule>> GetListPackageByPlanId(Guid id)
        {
            return await _context.Set<MaintananceSchedule>().Include(c => c.MaintenancePlan).Where(c => c.MaintenancePlanId == id).ToListAsync();
        }

        public async Task<List<MaintananceSchedule>> GetListPlanIdAndPackageCenterId(Guid planid, Guid id)
        {
            var existingSchedules = await _context.Set<MaintenanceInformation>()
        .Select(mi => mi.MaintananceScheduleId)
        .ToListAsync();

            var maintenanceServices = await _context.Set<MaintenanceService>()
                .Include(c => c.VehicleModel)
                    .ThenInclude(c => c.VehiclesBrand)
                .Include(ms => ms.ServiceCare)
                    .ThenInclude(sc => sc.MaintananceSchedule)
                    .ThenInclude(c => c.MaintenancePlan)
                            .Include(ms => ms.ServiceCare.MaintananceSchedule.MaintenanceVehiclesDetails) // Bao gồm MaintenanceVehiclesDetails

                .Where(ms => ms.MaintenanceCenterId == id && ms.ServiceCare.MaintananceSchedule.MaintenancePlanId == planid)
                .ToListAsync();

            var maintananceSchedules = maintenanceServices
        .Where(ms => ms.ServiceCare != null)
        .Select(ms => ms.ServiceCare.MaintananceSchedule)
        .Where(schedule => schedule != null && !existingSchedules.Contains(schedule.MaintananceScheduleId))
        .Distinct()
        .ToList();

            return maintananceSchedules;
        }

        public async Task<List<MaintananceSchedule>> GetListPlanIdAndPackageCenterIdBookingId(Guid planid, Guid id, Guid bookingId)
        {
            var existingSchedules = await _context.Set<MaintenanceInformation>()
                .Where(c => c.BookingId == bookingId)
       .Select(mi => mi.MaintananceScheduleId)
       .ToListAsync();

            var maintenanceServices = await _context.Set<MaintenanceService>()
                .Include(c => c.VehicleModel)
                    .ThenInclude(c => c.VehiclesBrand)
                .Include(ms => ms.ServiceCare)
                    .ThenInclude(sc => sc.MaintananceSchedule)
                    .ThenInclude(c => c.MaintenancePlan)
                            .Include(ms => ms.ServiceCare.MaintananceSchedule.MaintenanceVehiclesDetails) // Bao gồm MaintenanceVehiclesDetails

                .Where(ms => ms.MaintenanceCenterId == id && ms.ServiceCare.MaintananceSchedule.MaintenancePlanId == planid)
                .ToListAsync();

            var maintananceSchedules = maintenanceServices
        .Where(ms => ms.ServiceCare != null)
        .Select(ms => ms.ServiceCare.MaintananceSchedule)
        .Where(schedule => schedule != null && !existingSchedules.Contains(schedule.MaintananceScheduleId))
        .OrderBy(c=>c.MaintananceScheduleName)
        .Distinct()
        .ToList();

            return maintananceSchedules;
        }
    }
}
