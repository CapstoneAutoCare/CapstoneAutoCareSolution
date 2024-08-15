using Application.Dashboard;
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
    public class BookingRepositoryImp : GenericRepositoryImp<Booking>, IBookingRepository
    {
        public BookingRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<Booking>> GetAll()
        {
            var bookings = await _context.Set<Booking>()
                .Include(c => c.Client.Account)
                .Include(c => c.Vehicles.VehicleModel.VehiclesBrand)
                .Include(c => c.MaintenanceCenter.Account)
                //.Include(c => c.MaintenanceCenter.SparePartsItems)
                //.Include(c => c.MaintenanceCenter.MaintenanceServices)
                //.Include(c => c.MaintenanceInformation.MaintenanceSparePartInfos)
                //.Include(c => c.MaintenanceInformation.MaintenanceServiceInfos)
                //.Include(c => c.MaintenanceInformation.MaintenanceHistoryStatuses)
                .OrderByDescending(c => c.CreatedDate)
                .ToListAsync();


            return bookings;
        }



        public async Task<Booking> GetById(Guid? id)
        {
            var booking = await _context.Set<Booking>()
                .Include(c => c.Client.Account)
                .Include(c => c.Vehicles.VehicleModel.VehiclesBrand)
                .Include(c => c.MaintenanceCenter.Account)
                .Include(c => c.MaintenanceInformation)
                .ThenInclude(c => c.MaintenanceSparePartInfos)
                .Include(c => c.MaintenanceInformation.MaintenanceServiceInfos)
                .Include(c => c.MaintenanceInformation.MaintenanceHistoryStatuses)
                .OrderByDescending(c => c.CreatedDate)
                .FirstOrDefaultAsync(c => c.BookingId == id);
            if (booking == null)
            {
                throw new Exception("Not Found");
            }
            return booking;
        }

        public async Task<List<Booking>> GetListByCenter(Guid id)
        {
            return await _context.Set<Booking>()
                            .Include(c => c.Client.Account)
                            .Include(c => c.Vehicles.VehicleModel.VehiclesBrand)
                            .Include(c => c.MaintenanceCenter.Account)
                            .OrderByDescending(c => c.CreatedDate)
                            .Where(c => c.MaintenanceCenterId == id).ToListAsync();
        }

        public async Task<List<Booking>> GetListByCenterAndClient(Guid centerid, Guid clientId)
        {
            return await _context.Set<Booking>()
                            .Include(c => c.Client.Account)
                            .Include(c => c.Vehicles.VehicleModel.VehiclesBrand)
                            .Include(c => c.MaintenanceCenter.Account)
                            //.Include(c => c.MaintenanceInformation)
                            //.ThenInclude(c => c.MaintenanceSparePartInfos)
                            //.Include(c => c.MaintenanceInformation.MaintenanceServiceInfos)
                            //.Include(c => c.MaintenanceInformation.MaintenanceHistoryStatuses)
                            .OrderByDescending(c => c.CreatedDate)
                            .Where(c => c.ClientId == clientId && c.MaintenanceCenterId == centerid)
                            .ToListAsync();
        }
        public async Task<List<MonthlyBookingSummary>> GetBookingsByMonthByCenterId(Guid id)
        {
            var bookings = await _context.Set<Booking>()
                .Where(b => b.MaintenanceCenterId == id)
                .GroupBy(b => new { b.CreatedDate.Year, b.CreatedDate.Month })
                .Select(g => new MonthlyBookingSummary
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    BookingCount = g.Count()
                })
                .OrderBy(g => g.Year)
                .ThenBy(g => g.Month)
                .ToListAsync();

            return bookings;
        }
        public async Task<List<Booking>> GetListByClient(Guid id)
        {
            return await _context.Set<Booking>()
                            .Include(c => c.Client.Account)
                            .Include(c => c.Vehicles.VehicleModel.VehiclesBrand)
                            .Include(c => c.MaintenanceCenter.Account)
                            //.Include(c => c.MaintenanceInformation)
                            //.ThenInclude(c => c.MaintenanceSparePartInfos)
                            //.Include(c => c.MaintenanceInformation.MaintenanceServiceInfos)
                            //.Include(c => c.MaintenanceInformation.MaintenanceHistoryStatuses)
                            .OrderByDescending(c => c.CreatedDate)
                            .Where(c => c.ClientId == id)
                            .ToListAsync();
        }
    }
}
