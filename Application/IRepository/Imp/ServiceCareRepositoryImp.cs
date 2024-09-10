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
    public class ServiceCareRepositoryImp : GenericRepositoryImp<ServiceCares>, IServiceCareRepository
    {
        public ServiceCareRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<ServiceCares>> GetAll()
        {
            return await _context.Set<ServiceCares>()
                .Include(p => p.MaintananceSchedule)
                                .ThenInclude(c => c.MaintenancePlan)

                .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                                .OrderByDescending(p => p.CreatedDate)

                .ToListAsync();
        }


        public async Task<ServiceCares> GetByID(Guid? id)
        {
            var service = await _context.Set<ServiceCares>()
                .Include(p => p.MaintananceSchedule)
                                .ThenInclude(c => c.MaintenancePlan)

                .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                                .OrderByDescending(p => p.CreatedDate)

                .FirstOrDefaultAsync(x => x.ServiceCareId.Equals(id));
            if (service == null)
            {
                throw new Exception("Not Found");

            }
            return service;
        }

        public async Task<List<ServiceCares>> GetServiceCaresNotInMaintenanceServices(Guid centerId)
        {
            var listserviceId =
                 _context.Set<MaintenanceService>()

                .Where(c => c.MaintenanceCenterId == centerId)
                .Select(c => c.ServiceCareId).ToList();
            var service = await _context.Set<ServiceCares>()
                .Include(p => p.MaintananceSchedule)
                                .ThenInclude(c => c.MaintenancePlan)

                .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                                .OrderByDescending(p => p.CreatedDate)
                .Where(c => !listserviceId.Contains(c.ServiceCareId)).ToListAsync();

            return service;
        }
    }
}
