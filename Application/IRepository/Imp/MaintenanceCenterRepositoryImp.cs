using Application.IGenericRepository.Imp;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository.Imp
{
    public class MaintenanceCenterRepositoryImp : GenericRepositoryImp<MaintenanceCenter>, IMaintenanceCenterRepository
    {
        public MaintenanceCenterRepositoryImp(AppDBContext context) : base(context)
        {
        }
    }
}
