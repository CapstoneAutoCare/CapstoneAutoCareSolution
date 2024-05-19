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
    }
}
