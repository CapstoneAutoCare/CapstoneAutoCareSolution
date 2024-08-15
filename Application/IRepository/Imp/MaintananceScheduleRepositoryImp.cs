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
            return await _context.Set<MaintananceSchedule>().Include(c => c.VehicleModel).ThenInclude(c => c.VehiclesBrand).ToListAsync();
        }

        public async Task<MaintananceSchedule> GetByID(Guid? id)
        {
            var maintanance_schedule = await _context.Set<MaintananceSchedule>().Include(a => a.VehicleModel).ThenInclude(c => c.VehiclesBrand)
                .FirstOrDefaultAsync(c => c.MaintananceScheduleId == id);
            if (maintanance_schedule == null)
            {
                throw new Exception("Not Found");
            }
            return maintanance_schedule;
        }

        public async Task<List<MaintananceSchedule>> GetListPackageByCenterId(Guid id)
        {
            var maintenanceServices = await _context.Set<MaintenanceService>()
                .Include(c => c.VehicleModel)
                    .ThenInclude(c => c.VehiclesBrand)
                .Include(ms => ms.ServiceCare)
                    .ThenInclude(sc => sc.MaintananceSchedule)
                .Where(ms => ms.MaintenanceCenterId == id)
                .ToListAsync();

            var maintananceSchedules = maintenanceServices
                .Where(ms => ms.ServiceCare != null) 
                .Select(ms => ms.ServiceCare.MaintananceSchedule) 
                .Distinct()
                .ToList();

            return maintananceSchedules;
        }



    }
}
