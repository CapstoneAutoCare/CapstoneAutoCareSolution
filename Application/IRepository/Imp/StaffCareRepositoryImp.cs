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
    public class StaffCareRepositoryImp : GenericRepositoryImp<StaffCare>, IStaffCareRepository
    {
        public StaffCareRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<StaffCare>> GetAll()
        {
            return await _context.Set<StaffCare>()
                .Include(c => c.Account)
                .Include(c => c.MaintenanceCenter)
                .ToListAsync();
        }

        public async Task<StaffCare> GetById(Guid id)
        {
            var staffcare = await _context.Set<StaffCare>()
                            .Include(c => c.Account)
                            .Include(c => c.MaintenanceCenter)
                            .FirstOrDefaultAsync(c => c.StaffCareId == id);
            if (staffcare == null)
            {
                throw new Exception("Not Found");

            }
            return staffcare;
        }
    }
}
