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
    public class TechnicianMnRepositoryImp : GenericRepositoryImp<Technician>, ITechnicianRepository
    {
        public TechnicianMnRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<Technician>> GetAll()
        {
            return await _context.Set<Technician>().ToListAsync();
        }

        public Task<Technician> GetById(Guid id)
        {
            var model = _context.Set<Technician>()
                .Include(c => c.StaffCare)
                .Include(c => c.InformationMaintenance)
                .FirstOrDefaultAsync(c => c.TechnicianId.Equals(id));
            if (model == null)
            {
                throw new Exception("Not Found");
            }
            return model;
        }
    }
}
