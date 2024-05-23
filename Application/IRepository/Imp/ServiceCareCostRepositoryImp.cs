using Application.IGenericRepository.Imp;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository.Imp
{
    public class ServiceCareCostRepositoryImp : GenericRepositoryImp<MaintenanceService>, IMaintenanceServiceRepository
    {
        public ServiceCareCostRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public Task<List<MaintenanceService>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<MaintenanceService> GetByID(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
