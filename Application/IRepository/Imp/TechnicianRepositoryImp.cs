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
    public class TechnicianRepositoryImp : GenericRepositoryImp<Technician>, ITechicianRepository
    {
        public TechnicianRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<Technician>> GetAll()
        {
            return await _context.Set<Technician>()
                .Include(c => c.Account)
                .Include(c => c.MaintenanceCenter)
                .ToListAsync();
        }

        public async Task<Technician> GetById(Guid id)
        {
            var staffcare = await _context.Set<Technician>()
                            .Include(c => c.Account)
                            .Include(c => c.MaintenanceCenter)
                            .FirstOrDefaultAsync(c => c.TechnicianId == id);
            if (staffcare == null)
            {
                throw new Exception("Not Found");

            }
            return staffcare;
        }
    }
}
