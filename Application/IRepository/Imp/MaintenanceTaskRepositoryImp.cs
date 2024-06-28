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
    public class MaintenanceTaskRepositoryImp : GenericRepositoryImp<MaintenanceTask>, IMaintenanceTaskRepository
    {
        public MaintenanceTaskRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<MaintenanceTask>> GetAll()
        {
            return await _context.Set<MaintenanceTask>().ToListAsync();
        }

        public Task<MaintenanceTask> GetById(Guid id)
        {
            var model = _context.Set<MaintenanceTask>()
                .Include(c => c.Technician)
                .Include(c => c.InformationMaintenance)
                .FirstOrDefaultAsync(c => c.MaintenanceTaskId.Equals(id));
            if (model == null)
            {
                throw new Exception("Not Found");
            }
            return model;
        }
    }
}
