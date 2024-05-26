using Application.IGenericRepository.Imp;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository.Imp
{
    public class MaintenanceServiceInfoRepositoryImp : GenericRepositoryImp<MaintenanceServiceInfo>, IMaintenanceServiceInfoRepository
    {
        public MaintenanceServiceInfoRepositoryImp(AppDBContext context) : base(context)
        {
        }
    }
}
