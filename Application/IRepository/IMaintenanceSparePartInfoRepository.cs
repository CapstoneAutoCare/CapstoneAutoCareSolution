using Application.IGenericRepository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IMaintenanceSparePartInfoRepository: IGenericRepository<MaintenanceSparePartInfo>
    {
        Task<List<MaintenanceSparePartInfo>> GetAll();
        Task<List<MaintenanceSparePartInfo>> GetListByMainInfor(Guid id);
        Task<MaintenanceSparePartInfo> GetById(Guid id);

    }
}
