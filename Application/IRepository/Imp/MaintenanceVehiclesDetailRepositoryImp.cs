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
    public class MaintenanceVehiclesDetailRepositoryImp : GenericRepositoryImp<MaintenanceVehiclesDetail>, IMaintenanceVehiclesDetailRepository
    {
        public MaintenanceVehiclesDetailRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<MaintenanceVehiclesDetail> CheckNotMatch(Guid vehicle, Guid odo, Guid center)
        {
            return await _context.Set<MaintenanceVehiclesDetail>()
                .Include(c => c.MaintenanceCenter)
                .ThenInclude(c => c.Account)
                .Include(c => c.Vehicle)
                .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                .Include(c => c.MaintananceSchedule)
                .ThenInclude(c => c.MaintenancePlan)
                 .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                .FirstOrDefaultAsync(c => c.MaintenanceCenterId == center && c.VehiclesId == vehicle && c.MaintananceScheduleId == odo);




        }

        public async Task<List<MaintenanceVehiclesDetail>> GetAll()
        {
            return await _context.Set<MaintenanceVehiclesDetail>()
                .Include(c => c.MaintenanceCenter)
                .ThenInclude(c => c.Account)
                .Include(c => c.Vehicle)
                .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                .Include(c => c.MaintananceSchedule)
                .ThenInclude(c => c.MaintenancePlan)
                 .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                                                   .OrderBy(c => c.MaintananceSchedule.MaintananceScheduleName)

                .ToListAsync();
        }

        public async Task<MaintenanceVehiclesDetail> GetById(Guid? id)
        {
            var mvd = await _context.Set<MaintenanceVehiclesDetail>()
               .Include(c => c.MaintenanceCenter)
               .ThenInclude(c => c.Account)
               .Include(c => c.Vehicle)
               .ThenInclude(c => c.VehicleModel)
               .ThenInclude(c => c.VehiclesBrand)
               .Include(c => c.MaintananceSchedule)
               .ThenInclude(c => c.MaintenancePlan)
                .ThenInclude(c => c.VehicleModel)
               .ThenInclude(c => c.VehiclesBrand)
                                                  .OrderBy(c => c.MaintananceSchedule.MaintananceScheduleName)

               .FirstOrDefaultAsync(c => c.MaintenanceVehiclesDetailId == id);
            if (mvd == null)
            {
                throw new Exception("Khong tim thay");

            }
            return mvd;
        }

        public async Task<List<MaintenanceVehiclesDetail>> GetListByPlanAndVehicleAndCenter(Guid plan, Guid vehicle, Guid center)
        {
            return await _context.Set<MaintenanceVehiclesDetail>()
                                .Include(c => c.MaintenanceCenter)
                                                .ThenInclude(c => c.Account)

                           .Include(c => c.Vehicle)
                           .ThenInclude(c => c.VehicleModel)
                           .ThenInclude(c => c.VehiclesBrand)
                .Include(c => c.MaintananceSchedule)
                .ThenInclude(c => c.MaintenancePlan)
                 .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                           .Where(c => c.VehiclesId == vehicle && c.MaintananceSchedule.MaintenancePlanId == plan && c.MaintenanceCenterId == center

                           && !_context.Set<MaintenanceInformation>().Any(mi => mi.MaintenanceVehiclesDetailId == c.MaintenanceVehiclesDetailId)
                           )


                                   .OrderBy(c => c.MaintananceSchedule.MaintananceScheduleName).
ToListAsync();
        }

        public async Task<MaintenanceVehiclesDetail> GetListByPlanAndVehicleAndCenterWithStatusFinished(Guid plan, Guid vehicle, Guid center)
        {
            // Kiểm tra nếu đã tồn tại giao dịch "TRANSFERRED"
            var transactionExists = await _context.Set<Transactions>()
                .FirstOrDefaultAsync(t => t.MaintenancePlanId == plan && t.VehiclesId == vehicle && t.MaintenanceCenterId == center && t.Status == "TRANSFERRED");

            // Nếu không có giao dịch "TRANSFERRED" nào, tiếp tục truy vấn
            if (transactionExists == null)
            {
                return await _context.Set<MaintenanceVehiclesDetail>()
                    .Include(c => c.MaintenanceCenter)
                        .ThenInclude(c => c.Account)
                    .Include(c => c.Vehicle)
                        .ThenInclude(c => c.VehicleModel)
                        .ThenInclude(c => c.VehiclesBrand)
                    .Include(c => c.MaintananceSchedule)
                        .ThenInclude(c => c.MaintenancePlan)
                        .ThenInclude(c => c.VehicleModel)
                        .ThenInclude(c => c.VehiclesBrand)

                    .FirstOrDefaultAsync(c => c.MaintananceSchedule.MaintenancePlanId == plan
                                && c.VehiclesId == vehicle
                                && c.MaintenanceCenterId == center
                                && c.Status == "FINISHED");
            }
            return null;

        }

        public async Task<List<MaintenanceVehiclesDetail>> GetListByVehicleId(Guid id)
        {
            return await _context.Set<MaintenanceVehiclesDetail>()
                                .Include(c => c.MaintenanceCenter)
                                                .ThenInclude(c => c.Account)

                           .Include(c => c.Vehicle)
                           .ThenInclude(c => c.VehicleModel)
                           .ThenInclude(c => c.VehiclesBrand)
                .Include(c => c.MaintananceSchedule)
                .ThenInclude(c => c.MaintenancePlan)
                 .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                           .Where(c => c.VehiclesId == id)
                                   .OrderBy(c => c.MaintananceSchedule.MaintananceScheduleName).
ToListAsync();
        }




        // public async Task<List<MaintenanceVehiclesDetail>> GetListPlanIdAndPackageCenterIdBookingId(Guid planid, Guid id, Guid bookingId)
        // {
        //     var existingSchedules = await _context.Set<MaintenanceInformation>()
        //         .Where(c => c.BookingId == bookingId)
        //.Select(mi => mi.MaintenanceVehiclesDetailId)
        //.ToListAsync();




        //     var maintenanceServices = await _context.Set<MaintenanceService>()
        //         .Include(c => c.VehicleModel)
        //             .ThenInclude(c => c.VehiclesBrand)
        //         .Include(ms => ms.ServiceCare)
        //             .ThenInclude(sc => sc.MaintananceSchedule)
        //             .ThenInclude(c => c.MaintenancePlan)
        //                     .Include(ms => ms.ServiceCare.MaintananceSchedule.MaintenanceVehiclesDetails) // Bao gồm MaintenanceVehiclesDetails

        //         .Where(ms => ms.MaintenanceCenterId == id && ms.ServiceCare.MaintananceSchedule.MaintenancePlanId == planid)
        //         .ToListAsync();

        //     var maintananceSchedules = maintenanceServices
        // .Where(ms => ms.ServiceCare != null)
        // .Select(ms => ms.ServiceCare.MaintananceSchedule)
        // .Where(schedule => schedule != null && !existingSchedules.Contains(schedule.MaintananceScheduleId))
        // .OrderBy(c => c.MaintananceScheduleName)
        // .Distinct()
        // .ToList();

        //     return maintananceSchedules;
        // }
    }
}
