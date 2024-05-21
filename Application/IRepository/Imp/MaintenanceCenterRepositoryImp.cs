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
    public class MaintenanceCenterRepositoryImp : GenericRepositoryImp<MaintenanceCenter>, IMaintenanceCenterRepository
    {
        public MaintenanceCenterRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<MaintenanceCenter>> GetAll()
        {
            return await _context.Set<MaintenanceCenter>().Include(c => c.Account).ToListAsync();
        }

        public async Task<MaintenanceCenter> GetById(Guid id)
        {
            var center = await _context.Set<MaintenanceCenter>()
                .Include(c => c.Account)
                .FirstOrDefaultAsync(c => c.MaintenanceCenterId == id);
            if (center == null)
            {
                throw new Exception("Not Found");

            }
            return center;
        }
    }
}
