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
    public class MaintenanceHistoryStatusesRepositoryImp : GenericRepositoryImp<MaintenanceHistoryStatus>, IMaintenanceHistoryStatusesRepository
    {
        public MaintenanceHistoryStatusesRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<MaintenanceHistoryStatus> CheckExistNameByNameAndIdInfor(Guid id, string status)
        {
            var mhs = await _context.Set<MaintenanceHistoryStatus>()
                            .Include(c => c.MaintenanceInformation)
                            .FirstOrDefaultAsync(c => c.MaintenanceInformationId == id
                            && c.Status.ToUpper().Contains(status.ToUpper()));
            if (mhs != null)
            {
                throw new Exception("EXISTED");
            }
            return mhs;
        }

        public Task<List<MaintenanceHistoryStatus>> GetAll()
        {
            return _context.Set<MaintenanceHistoryStatus>().Include(c => c.MaintenanceInformation).ToListAsync();
        }

        public async Task<MaintenanceHistoryStatus> GetById(Guid id)
        {
            var mhs = await _context.Set<MaintenanceHistoryStatus>()
                .Include(c => c.MaintenanceInformation)
                .FirstOrDefaultAsync(c => c.MaintenanceHistoryStatusId == id);
            if (mhs == null)
            {
                throw new Exception("not found");
            }
            return mhs;
        }
    }
}
