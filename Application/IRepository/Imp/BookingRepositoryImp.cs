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
                            .Where(c => c.ClientId == clientId && c.MaintenanceCenterId == centerid)
                            .ToListAsync();
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
                            .Where(c => c.ClientId == id)
                            .ToListAsync();
        }
    }
}
