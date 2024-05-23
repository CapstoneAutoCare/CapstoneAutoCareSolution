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
    public class MaintananceScheduleRepositoryImp : GenericRepositoryImp<MaintananceSchedule>, IMaintananceScheduleRepository
    {
        public MaintananceScheduleRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<MaintananceSchedule>> GetAll()
        {
            return await _context.Set<MaintananceSchedule>().Include(c => c.VehicleModel).ToListAsync();
        }

        public async Task<MaintananceSchedule> GetByID(Guid id)
        {
            var maintanance_schedule = await _context.Set<MaintananceSchedule>().Include(a => a.VehicleModel)
                .FirstOrDefaultAsync(c => c.MaintananceScheduleId == id);
            if(maintanance_schedule == null)
            {
                throw new Exception("Not Found");
            }
            return maintanance_schedule;
        }
    }
}
