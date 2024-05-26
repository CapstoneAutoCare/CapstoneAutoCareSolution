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
            return await _context.Set<Booking>().Include(c => c.Client).Include(c => c.Vehicles).ToListAsync();
        }

        public async Task<Booking> GetById(Guid? id)
        {
            var booking = await _context.Set<Booking>().Include(c => c.Client).FirstOrDefaultAsync(c => c.BookingId == id);
            if (booking == null)
            {
                throw new Exception("Not Found");
            }
            return booking;
        }
    }
}
