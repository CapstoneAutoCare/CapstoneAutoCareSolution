using Application.IGenericRepository.Imp;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository.Imp
{
    public class MaintenanceServiceCostRepositoryImp : GenericRepositoryImp<MaintenanceServiceCost>, IMaintenanceServiceCostRepository
    {
        public MaintenanceServiceCostRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public Task<List<MaintenanceServiceCost>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<MaintenanceServiceCost> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
