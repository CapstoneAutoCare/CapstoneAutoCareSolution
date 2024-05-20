using Application.IGenericRepository.Imp;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository.Imp
{
    public class MaintenanceHistoryStatusesRepositoryImp : GenericRepositoryImp<MaintenanceHistoryStatus>, IMaintenanceHistoryStatusesRepository
    {
        public MaintenanceHistoryStatusesRepositoryImp(AppDBContext context) : base(context)
        {
        }
    }
}
