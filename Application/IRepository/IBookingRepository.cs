using Application.Dashboard;
using Application.IGenericRepository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IBookingRepository: IGenericRepository<Booking>
    {
        Task<Booking> GetById(Guid? id);
        Task<List<Booking>> GetAll();
        Task<List<Booking>> GetListByClient(Guid id);
        Task<List<Booking>> GetListByCenterAndClient (Guid centerid, Guid clientId);
        Task<List<Booking>> GetListByCenter(Guid id);
        Task<List<MonthlyBookingSummary>> GetBookingsByMonthByCenterId(Guid id);
        Task<List<MonthlyBookingSummary>> GetBookingsByMonthInYearByCenterId(Guid centerId, int year);
        Task<Booking> GetByInforid(Guid inforid);

    }
}
