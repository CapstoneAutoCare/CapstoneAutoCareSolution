using Application.IGenericRepository.Imp;
using Domain.Entities;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository.Imp
{
    public class MaintenanceTaskSparePartInfoRepositoryImp : GenericRepositoryImp<MaintenanceTaskSparePartInfo>, IMaintenanceTaskSparePartInfoRepository
    {
        public MaintenanceTaskSparePartInfoRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<MaintenanceTaskSparePartInfo>> GetListByActiveAndTask(Guid id)
        {
            return await _context.Set<MaintenanceTaskSparePartInfo>()
                .Include(c => c.MaintenanceTask)
                .Where(c => c.MaintenanceTaskId.Equals(id) && c.Status.Equals(EnumStatus.ACTIVE.ToString()))
                .ToListAsync();
        }
    }
}
