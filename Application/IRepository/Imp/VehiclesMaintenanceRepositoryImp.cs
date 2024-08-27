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
    public class VehiclesMaintenanceRepositoryImp : GenericRepositoryImp<VehiclesMaintenance>, IVehiclesMaintenanceRepository
    {
        public VehiclesMaintenanceRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<VehiclesMaintenance>> GetAll()
        {
            return await _context.Set<VehiclesMaintenance>().Include(c => c.MaintenanceCenter).ThenInclude(c => c.Account).Include(c => c.VehiclesBrand).ToListAsync();
        }

        public async Task<List<VehiclesMaintenance>> GetListByCenter(Guid id)
        {
            return await _context.Set<VehiclesMaintenance>()
                .Include(c => c.MaintenanceCenter)
                .ThenInclude(c => c.Account)
                .Include(c => c.VehiclesBrand)
                .Where(c => c.MaintenanceCenterId == id && c.VehiclesBrand.Status == "ACTIVE")
                .ToListAsync();
        }

       
    }
}
