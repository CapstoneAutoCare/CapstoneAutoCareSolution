using Application.Dashboard;
using Application.IGenericRepository.Imp;
using Domain.Entities;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository.Imp
{
    public class InformationMaintenanceRepositoryImp : GenericRepositoryImp<MaintenanceInformation>, IInformationMaintenanceRepository
    {
        public InformationMaintenanceRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<MaintenanceInformation>> GetAll()
        {
            return await _context.Set<MaintenanceInformation>()
                .Include(c => c.Booking)
                .ThenInclude(c => c.Vehicles)
                .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                .Include(c => c.OdoHistory)
                .Include(c => c.CustomerCare)
                .Include(c => c.MaintenanceSparePartInfos)
                .ThenInclude(c => c.SparePartsItemCost.SparePartsItem)
                .Include(c => c.MaintenanceHistoryStatuses)
                .Include(c => c.MaintenanceServiceInfos)
                .ThenInclude(c => c.MaintenanceServiceCost.MaintenanceService)
                .OrderByDescending(c => c.CreatedDate)
                .ToListAsync();
        }

        public async Task<MaintenanceInformation> GetByBookingId(Guid id)
        {
            var check = await _context.Set<MaintenanceInformation>()
                             .Include(c => c.Booking)
                             .ThenInclude(c => c.Vehicles)
                             .ThenInclude(c => c.VehicleModel)
                             .ThenInclude(c => c.VehiclesBrand)
                             .Include(c => c.OdoHistory)
                             .Include(c => c.CustomerCare)
                             .Include(c => c.MaintenanceSparePartInfos)
                             .ThenInclude(c => c.SparePartsItemCost.SparePartsItem)
                             .Include(c => c.MaintenanceHistoryStatuses)
                             .Include(c => c.MaintenanceServiceInfos)
                             .ThenInclude(c => c.MaintenanceServiceCost.MaintenanceService)
                             .FirstOrDefaultAsync(c => c.BookingId == id);
            if (check == null)
            {
                throw new Exception("CUSTOMERCARE should provide products");
            }
            return check;
        }

        public async Task<MaintenanceInformation> GetById(Guid id)
        {
            var mainifor = await _context.Set<MaintenanceInformation>()
                .Include(c => c.Booking)
                .ThenInclude(c => c.Vehicles)
                .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                .Include(c => c.OdoHistory)
                .Include(c => c.CustomerCare)
                .Include(c => c.MaintenanceSparePartInfos)
                .ThenInclude(c => c.SparePartsItemCost.SparePartsItem)
                .Include(c => c.MaintenanceHistoryStatuses)
                .Include(c => c.MaintenanceServiceInfos)
                .ThenInclude(c => c.MaintenanceServiceCost.MaintenanceService)
                .FirstOrDefaultAsync(c => c.InformationMaintenanceId == id);
            if (mainifor == null)
            {
                throw new Exception("Not Found");
            }
            return mainifor;
        }

        public async Task<List<MaintenanceInformation>> GetListByCenter(Guid id)
        {
            return await _context.Set<MaintenanceInformation>()
                            .Include(c => c.Booking)
                .ThenInclude(c => c.Vehicles)
                .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                            .Include(c => c.OdoHistory)
                            .Include(c => c.CustomerCare)
                .Include(c => c.MaintenanceSparePartInfos)
                .ThenInclude(c => c.SparePartsItemCost.SparePartsItem)
                .Include(c => c.MaintenanceHistoryStatuses)
                .Include(c => c.MaintenanceServiceInfos)
                .ThenInclude(c => c.MaintenanceServiceCost.MaintenanceService)
                            .Where(c => c.Booking.MaintenanceCenterId == id)
                            .OrderByDescending(c => c.CreatedDate)
                            .ToListAsync();
        }

        public async Task<List<MaintenanceInformation>> GetListByCenterAndStatus(Guid id, string status)
        {
            return await _context.Set<MaintenanceInformation>()
                           .Include(c => c.Booking)
                .ThenInclude(c => c.Vehicles)
                .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                           .Include(c => c.OdoHistory)
                           .Include(c => c.CustomerCare)
                           .Include(c => c.MaintenanceSparePartInfos)
                           .ThenInclude(c => c.SparePartsItemCost.SparePartsItem)
                           .Include(c => c.MaintenanceHistoryStatuses)
                           .Include(c => c.MaintenanceServiceInfos)
                           .ThenInclude(c => c.MaintenanceServiceCost.MaintenanceService)
                           .Where(c => c.Booking.MaintenanceCenterId == id && c.Status.Equals(status)
                           )
                           .OrderByDescending(c => c.CreatedDate)
                           .ToListAsync();
        }

        public async Task<List<MaintenanceInformation>> GetListByClient(Guid id)
        {
            return await _context.Set<MaintenanceInformation>()
                            .Include(c => c.Booking)
                .ThenInclude(c => c.Vehicles)
                .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                            .Include(c => c.OdoHistory)
                            .Include(c => c.CustomerCare)
                .Include(c => c.MaintenanceSparePartInfos)
                .ThenInclude(c => c.SparePartsItemCost.SparePartsItem)
                .Include(c => c.MaintenanceHistoryStatuses)
                .Include(c => c.MaintenanceServiceInfos)
                .ThenInclude(c => c.MaintenanceServiceCost.MaintenanceService)
                            .Where(c => c.Booking.ClientId == id)
                            .OrderByDescending(c => c.CreatedDate)
                            .ToListAsync();
        }


        public async Task<List<MaintenanceInformation>> GetListByCenterAndStatusCheckinAndTaskInactive(Guid id)
        {
            var result = await _context.Set<MaintenanceInformation>().Include(c => c.Booking)
                .ThenInclude(c => c.Vehicles)
                .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                .Where(m => m.Booking.MaintenanceCenterId.Equals(id)
                && m.Status.Equals(STATUSENUM.STATUSMI.CHECKIN.ToString())
                && (!m.MaintenanceTasks.Any()
                || m.MaintenanceTasks.Any(c => c.Status.Equals(STATUSENUM.STATUSBOOKING.CANCELLED.ToString()))))
                .ToListAsync();
            return result;
        }

        public async Task<(List<MaintenanceInformation> Costs, float TotalCost, int Count)> TotalGetListByCenter(Guid id)
        {
            var i = await _context.Set<MaintenanceInformation>()
                .Where(c => c.Booking.MaintenanceCenterId == id)
                .OrderByDescending(c => c.CreatedDate)
                .ToListAsync();
            var totalCost = i.Sum(c => c.TotalPrice);
            int count = i.Count;

            return (i, totalCost, count);
        }
        public async Task<List<MonthlyBookingSummary>> GetInforPAIDByMonthInYearByCenterId(Guid centerId, int year)
        {
            var bookings = await _context.Set<MaintenanceInformation>()
                              .Where(m => m.Booking.BookingDate.Year == year && m.Booking.MaintenanceCenterId == centerId && m.Status == "PAID")
                                .GroupBy(m => new { m.Booking.BookingDate.Month, m.Booking.BookingDate.Year })
                                              .ToListAsync();

            var monthlySummary = bookings
                //.GroupBy(b => new { b.BookingDate.Year, b.BookingDate.Month })
                .Select(g => new MonthlyBookingSummary
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    BookingCount = g.Count()
                })
                .OrderBy(m => m.Year).ThenBy(m => m.Month)
                .ToList();

            return monthlySummary;
        }
        public async Task<List<MonthlyRevenue>> GetMonthlyRevenue(int year, Guid id)
        {
            var monthlyRevenues = await _context.Receipts
                .Include(c => c.InformationMaintenance)
                .ThenInclude(c => c.Booking)
                .Where(m => m.InformationMaintenance.Booking.BookingDate.Year == year && m.InformationMaintenance.Booking.MaintenanceCenterId == id && m.InformationMaintenance.Status == "PAID")
                .GroupBy(m => new { m.InformationMaintenance.Booking.BookingDate.Month, m.InformationMaintenance.Booking.BookingDate.Year })
                .Select(g => new
                {
                    Month = g.Key.Month,
                    Revenue = g.Sum(m => m.TotalAmount)
                })
                .OrderBy(g => g.Month)
                .ToListAsync();

            var result = monthlyRevenues
                .Select(mr => new MonthlyRevenue
                {
                    Month = mr.Month.ToString("00"),
                    Revenue = mr.Revenue
                })
                .ToList();

            return result;
        }

        public async Task<List<MaintenanceInformation>> GetListByBookingId(Guid id)
        {
            return await _context.Set<MaintenanceInformation>()
                               .Include(c => c.Booking)
                               .ThenInclude(c => c.Vehicles)
                               .ThenInclude(c => c.VehicleModel)
                              .ThenInclude(c => c.VehiclesBrand)
                               .Include(c => c.OdoHistory)
                               .Include(c => c.CustomerCare)
                               .Include(c => c.MaintenanceSparePartInfos)
                               .ThenInclude(c => c.SparePartsItemCost.SparePartsItem)
                               .Include(c => c.MaintenanceHistoryStatuses)
                               .Include(c => c.MaintenanceServiceInfos)
                               .ThenInclude(c => c.MaintenanceServiceCost.MaintenanceService)
                               .Where(c => c.BookingId == id).ToListAsync();
        }

        public async Task<MaintenanceInformation> GetByBookingIdAndScheduleId(Guid id, Guid scheduleId, Guid vehicleId)
        {
            var main = await _context.Set<MaintenanceInformation>()
                               .Include(c => c.Booking)
                               .ThenInclude(c => c.Vehicles)
                               .ThenInclude(c => c.VehicleModel)
                              .ThenInclude(c => c.VehiclesBrand)
                               .Include(c => c.OdoHistory)
                               .Include(c => c.CustomerCare)
                               .Include(c => c.MaintenanceSparePartInfos)
                               .ThenInclude(c => c.SparePartsItemCost.SparePartsItem)
                               .Include(c => c.MaintenanceHistoryStatuses)
                               .Include(c => c.MaintenanceServiceInfos)
                               .ThenInclude(c => c.MaintenanceServiceCost.MaintenanceService)
                               .FirstOrDefaultAsync(c => c.BookingId == id && c.MaintenanceVehiclesDetail.MaintananceScheduleId == scheduleId && c.MaintenanceVehiclesDetail.VehiclesId == vehicleId);
            if (main == null) { throw new Exception("Khong tim thay"); }
            return main;
        }

        public async Task<MaintenanceInformation> GetByMVDId(Guid id)
        {
            var main = await _context.Set<MaintenanceInformation>()
                              .Include(c => c.Booking)
                              .ThenInclude(c => c.Vehicles)
                              .ThenInclude(c => c.VehicleModel)
                             .ThenInclude(c => c.VehiclesBrand)
                              .Include(c => c.OdoHistory)
                              .Include(c => c.CustomerCare)
                              .Include(c => c.MaintenanceSparePartInfos)
                              .ThenInclude(c => c.SparePartsItemCost.SparePartsItem)
                              .Include(c => c.MaintenanceHistoryStatuses)
                              .Include(c => c.MaintenanceServiceInfos)
                              .ThenInclude(c => c.MaintenanceServiceCost.MaintenanceService)
                              .FirstOrDefaultAsync(c => c.MaintenanceVehiclesDetailId == id);
            if (main == null) { throw new Exception("Khong tim thay"); }
            return main;
        }

        public async Task<List<MaintenanceInformation>> GetListByPlanAndVehicleAndCenterAndStatusWatingbycar(Guid planId, Guid vehicleId, Guid centerId)
        {
            return await _context.Set<MaintenanceInformation>()
                              .Include(c => c.Booking)
                              .ThenInclude(c => c.Vehicles)
                              .ThenInclude(c => c.VehicleModel)
                             .ThenInclude(c => c.VehiclesBrand)
                              .Include(c => c.OdoHistory)
                              .Include(c => c.CustomerCare)
                              .Include(c => c.MaintenanceSparePartInfos)
                              .ThenInclude(c => c.SparePartsItemCost.SparePartsItem)
                              .Include(c => c.MaintenanceHistoryStatuses)
                              .Include(c => c.MaintenanceServiceInfos)
                              .ThenInclude(c => c.MaintenanceServiceCost.MaintenanceService)
                              .Include(c=>c.MaintenanceVehiclesDetail)
                              .ThenInclude(c=>c.MaintananceSchedule)
                              .ThenInclude(c=>c.MaintenancePlan)
                              .Where(c => c.MaintenanceVehiclesDetail.MaintananceSchedule.MaintenancePlanId == planId
                              && c.MaintenanceVehiclesDetail.VehiclesId == vehicleId
                              && c.MaintenanceVehiclesDetail.MaintenanceCenterId == centerId && c.Status==EnumStatus.WAITINGBYCAR.ToString())
                              .OrderBy(c => c.MaintenanceVehiclesDetail.MaintananceSchedule.MaintananceScheduleName)
                              .ToListAsync();
        }
    }
}
