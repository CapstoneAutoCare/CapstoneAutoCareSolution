using Application.IGenericRepository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IMaintenanceTaskSparePartInfoRepository : IGenericRepository<MaintenanceTaskSparePartInfo>
    {
        Task<List<MaintenanceTaskSparePartInfo>> GetListByActiveAndTask(Guid id);
        Task<MaintenanceTaskSparePartInfo> GetById(Guid id);
    }
}
