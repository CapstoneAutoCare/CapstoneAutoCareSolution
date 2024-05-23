using Application.IGenericRepository.Imp;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository.Imp
{
    public class MaintenancePlanRepositoryImp : GenericRepositoryImp<MaintenancePlan>, IMaintenancePlanRepository
    {
        public MaintenancePlanRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public Task<List<MaintenancePlan>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<MaintenancePlan> GetByID(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
