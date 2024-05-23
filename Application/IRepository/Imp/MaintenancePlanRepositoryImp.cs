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
    public class MaintenancePlanRepositoryImp : GenericRepositoryImp<MaintenancePlan>, IMaintenancePlanRepository
    {
        public MaintenancePlanRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<MaintenancePlan>> GetAll()
        {
            return await _context.Set<MaintenancePlan>().Include(p => p.MaintananceSchedule).ToListAsync();
        }

        public async Task<MaintenancePlan> GetByID(Guid id)
        {
            var mp = await _context.Set<MaintenancePlan>().Include(p => p.MaintananceSchedule).FirstOrDefaultAsync(x => x.Equals(id));
            if (mp == null)
            {
                throw new Exception("Not Found");

            }
            return mp;
        }
    }
}
