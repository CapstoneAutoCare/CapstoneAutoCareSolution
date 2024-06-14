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
    public class InformationMaintenanceRepositoryImp : GenericRepositoryImp<MaintenanceInformation>, IInformationMaintenanceRepository
    {
        public InformationMaintenanceRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<MaintenanceInformation>> GetAll()
        {
            return await _context.Set<MaintenanceInformation>()
                .Include(c => c.Booking)
                .Include(c => c.OdoHistory)
                .Include(c => c.CustomerCare)
                .Include(c => c.MaintenanceSparePartInfos)
                .Include(c => c.MaintenanceHistoryStatuses)
                .Include(c => c.MaintenanceServiceInfos)
                .ToListAsync();
        }

        public async Task<MaintenanceInformation> GetById(Guid id)
        {
            var mainifor = await _context.Set<MaintenanceInformation>()
                .Include(c => c.Booking)
                .Include(c => c.OdoHistory)
                .Include(c => c.CustomerCare)
                .Include(c => c.MaintenanceSparePartInfos)
                .Include(c => c.MaintenanceHistoryStatuses)
                .Include(c => c.MaintenanceServiceInfos)
                .FirstOrDefaultAsync(c => c.InformationMaintenanceId == id);
            if (mainifor == null)
            {
                throw new Exception("Not Found");
            }
            return mainifor;
        }

        public async Task<List<MaintenanceInformation>> GetListByClient(Guid id)
        {
            return await _context.Set<MaintenanceInformation>()
                            .Include(c => c.Booking)
                            .Include(c => c.OdoHistory)
                            .Include(c => c.CustomerCare)
                            .Include(c => c.MaintenanceSparePartInfos)
                            .Include(c => c.MaintenanceHistoryStatuses)
                            .Include(c => c.MaintenanceServiceInfos)
                            .Where(c => c.Booking.ClientId == id)
                            .ToListAsync();
        }
    }
}
