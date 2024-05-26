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
    public class ServiceCareRepositoryImp : GenericRepositoryImp<ServiceCare>, IServiceCareRepository
    {
        public ServiceCareRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<ServiceCare>> GetAll()
        {
            return await _context.Set<ServiceCare>().Include(p => p.MaintenancePlan).ToListAsync();
        }

        public async Task<ServiceCare> GetByID(Guid? id)
        {
            var service = await _context.Set<ServiceCare>().Include(p => p.MaintenancePlan).FirstOrDefaultAsync(x => x.ServiceCareId.Equals(id));
            if (service == null)
            {
                throw new Exception("Not Found");

            }
            return service;
        }
    }
}
