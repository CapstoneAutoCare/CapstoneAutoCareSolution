using Application.IGenericRepository;
using Application.IGenericRepository.Imp;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IMaintenanceServiceInfoRepository : IGenericRepository<MaintenanceServiceInfo>
    {
        Task<List<MaintenanceServiceInfo>> GetAll();
        Task<MaintenanceServiceInfo> GetById(Guid id);
    }
}
