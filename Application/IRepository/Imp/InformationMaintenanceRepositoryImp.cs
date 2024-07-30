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
                .ThenInclude(c=>c.Vehicles)
                .ThenInclude(c=>c.VehicleModel)
                .ThenInclude(c=>c.VehiclesBrand)
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
            var result = await _context.Set<MaintenanceInformation>()
                .Where(m => m.Booking.MaintenanceCenterId.Equals(id)
                && m.Status.Equals(STATUSENUM.STATUSMI.CHECKIN.ToString())
                && (!m.MaintenanceTasks.Any()
                || m.MaintenanceTasks.Any(c => c.Status.Equals(STATUSENUM.STATUSBOOKING.CANCELLED.ToString()))))
                .ToListAsync();
            return result;
        }

        
    }
}
