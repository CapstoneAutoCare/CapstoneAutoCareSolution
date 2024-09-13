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
    public class MaintenanceVehiclesDetailRepositoryImp : GenericRepositoryImp<MaintenanceVehiclesDetail>, IMaintenanceVehiclesDetailRepository
    {
        public MaintenanceVehiclesDetailRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<MaintenanceVehiclesDetail>> GetAll()
        {
            return await _context.Set<MaintenanceVehiclesDetail>()
                .Include(c=>c.MaintenanceCenter)
                .ThenInclude(c=>c.Account)
                .Include(c => c.Vehicle)
                .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                .Include(c=>c.MaintananceSchedule)
                .ThenInclude(c=>c.MaintenancePlan)
                 .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                                                   .OrderBy(c => c.MaintananceSchedule.MaintananceScheduleName)

                .ToListAsync();
        }



        public async Task<List<MaintenanceVehiclesDetail>> GetListByVehicleId(Guid id)
        {
            return await _context.Set<MaintenanceVehiclesDetail>()
                                .Include(c => c.MaintenanceCenter)
                                                .ThenInclude(c => c.Account)

                           .Include(c => c.Vehicle)
                           .ThenInclude(c => c.VehicleModel)
                           .ThenInclude(c => c.VehiclesBrand)
                .Include(c => c.MaintananceSchedule)
                .ThenInclude(c => c.MaintenancePlan)
                 .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                           .Where(c => c.VehiclesId == id)
                                   .OrderBy(c => c.MaintananceSchedule.MaintananceScheduleName).
ToListAsync();
        }
    }
}
