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
    public class MaintenanceTaskRepositoryImp : GenericRepositoryImp<MaintenanceTask>, IMaintenanceTaskRepository
    {
        public MaintenanceTaskRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<MaintenanceTask> CheckExistByTechAndInfor(Guid techId, Guid inforId)
        {
            var i = await _context.Set<MaintenanceTask>()
                .Include(c => c.MaintenanceTaskSparePartInfos)
                .ThenInclude(c => c.MaintenanceSparePartInfo)
                .ThenInclude(c => c.SparePartsItemCost)
                .ThenInclude(c => c.SparePartsItem)
                .Include(c => c.MaintenanceTaskServiceInfos)
                .ThenInclude(c => c.MaintenanceServiceInfo)
                .ThenInclude(c => c.MaintenanceServiceCost)
                .ThenInclude(c => c.MaintenanceService)
                .Include(c => c.Technician)
                .Include(c => c.InformationMaintenance)
                 .FirstOrDefaultAsync(c => c.TechnicianId.Equals(techId) && c.InformationMaintenanceId.Equals(inforId));
            if (i != null)
            {
                throw new Exception("Exist");
            }
            return i;
        }

        public async Task<MaintenanceTask> CheckTaskByInforId(Guid id, string status)
        {
            var i = await _context.Set<MaintenanceTask>()
                .Include(c => c.MaintenanceTaskSparePartInfos)
                .ThenInclude(c => c.MaintenanceSparePartInfo)
                .ThenInclude(c => c.SparePartsItemCost)
                .ThenInclude(c => c.SparePartsItem)
                .Include(c => c.MaintenanceTaskServiceInfos)
                .ThenInclude(c => c.MaintenanceServiceInfo)
                .ThenInclude(c => c.MaintenanceServiceCost)
                .ThenInclude(c => c.MaintenanceService)
                .Include(c => c.Technician)
                .Include(c => c.InformationMaintenance)
                 .FirstOrDefaultAsync(c => c.InformationMaintenanceId.Equals(id) && c.Status.Equals(status));
            if(i == null)
            {
                throw new Exception("Null Status Task");
            }
            return i;
        }

        public async Task<List<MaintenanceTask>> GetAll()
        {
            return await _context.Set<MaintenanceTask>()
                .Include(c => c.MaintenanceTaskSparePartInfos)
                .ThenInclude(c => c.MaintenanceSparePartInfo)
                .ThenInclude(c => c.SparePartsItemCost)
                .ThenInclude(c => c.SparePartsItem)
                .Include(c => c.MaintenanceTaskServiceInfos)
                .ThenInclude(c => c.MaintenanceServiceInfo)
                .ThenInclude(c => c.MaintenanceServiceCost)
                .ThenInclude(c => c.MaintenanceService)
                .Include(c => c.Technician)
                .Include(c => c.InformationMaintenance)
                                .OrderByDescending(c => c.CreatedDate).ToListAsync();
        }

        public Task<MaintenanceTask> GetById(Guid id)
        {
            var model = _context.Set<MaintenanceTask>()
                .Include(c => c.MaintenanceTaskSparePartInfos)
                .ThenInclude(c => c.MaintenanceSparePartInfo)
                .ThenInclude(c => c.SparePartsItemCost)
                .ThenInclude(c => c.SparePartsItem)
                .Include(c => c.MaintenanceTaskServiceInfos)
                .ThenInclude(c=>c.MaintenanceServiceInfo)
                .ThenInclude(c=>c.MaintenanceServiceCost)
                .ThenInclude(c=>c.MaintenanceService)
                .Include(c => c.Technician)
                .Include(c => c.InformationMaintenance)
                .FirstOrDefaultAsync(c => c.MaintenanceTaskId.Equals(id));
            if (model == null)
            {
                throw new Exception("Not Found");
            }
            return model;
        }

        public async Task<List<MaintenanceTask>> GetListByCenter(Guid id)
        {
            return await _context.Set<MaintenanceTask>()
                .Include(c => c.MaintenanceTaskSparePartInfos)
                .ThenInclude(c => c.MaintenanceSparePartInfo)
                .ThenInclude(c => c.SparePartsItemCost)
                .ThenInclude(c => c.SparePartsItem)
                .Include(c => c.MaintenanceTaskServiceInfos)
                .ThenInclude(c => c.MaintenanceServiceInfo)
                .ThenInclude(c => c.MaintenanceServiceCost)
                .ThenInclude(c => c.MaintenanceService)
                .Include(c => c.Technician)
                .Include(c => c.InformationMaintenance)
                .Where(c => c.Technician.CenterId == id)
                .OrderByDescending(c => c.CreatedDate)
                .ToListAsync();
        }

        public async Task<List<MaintenanceTask>> GetListByCustomerCare(Guid id)
        {
            return await _context.Set<MaintenanceTask>()
                .Include(c => c.MaintenanceTaskSparePartInfos)
                .Include(c => c.MaintenanceTaskServiceInfos)
                .Include(c => c.Technician)
                .Include(c => c.InformationMaintenance)
                .Where(c => c.InformationMaintenance.CustomerCareId == id)
                .OrderByDescending(c => c.CreatedDate)
                .ToListAsync();
        }

        public async Task<List<MaintenanceTask>> GetListByInfor(Guid id)
        {
            return await _context.Set<MaintenanceTask>()
                .Include(c => c.MaintenanceTaskSparePartInfos)
                .ThenInclude(c => c.MaintenanceSparePartInfo)
                .ThenInclude(c => c.SparePartsItemCost)
                .ThenInclude(c => c.SparePartsItem)
                .Include(c => c.MaintenanceTaskServiceInfos)
                .ThenInclude(c => c.MaintenanceServiceInfo)
                .ThenInclude(c => c.MaintenanceServiceCost)
                .ThenInclude(c => c.MaintenanceService)
                .Include(c => c.Technician)
                .Include(c => c.InformationMaintenance)
                .Where(c => c.InformationMaintenance.InformationMaintenanceId == id)
                .OrderByDescending(c => c.CreatedDate)
                .ToListAsync();
        }

        public async Task<List<MaintenanceTask>> GetListByTech(Guid id)
        {
            return await _context.Set<MaintenanceTask>()
                .Include(c => c.MaintenanceTaskSparePartInfos)
                .ThenInclude(c => c.MaintenanceSparePartInfo)
                .ThenInclude(c => c.SparePartsItemCost)
                .ThenInclude(c => c.SparePartsItem)
                .Include(c => c.MaintenanceTaskServiceInfos)
                .ThenInclude(c => c.MaintenanceServiceInfo)
                .ThenInclude(c => c.MaintenanceServiceCost)
                .ThenInclude(c => c.MaintenanceService)
                .Include(c => c.Technician)
                .Include(c => c.InformationMaintenance)
                .Where(c => c.TechnicianId == id)
                .OrderByDescending(c => c.CreatedDate)
                .ToListAsync();
        }

        public async Task<List<MaintenanceTask>> GetListStatusDifCancelledByInfor(Guid id)
        {
            return await _context.Set<MaintenanceTask>()
                .Include(c => c.MaintenanceTaskSparePartInfos)
                .ThenInclude(c => c.MaintenanceSparePartInfo)
                .ThenInclude(c => c.SparePartsItemCost)
                .ThenInclude(c => c.SparePartsItem)
                .Include(c => c.MaintenanceTaskServiceInfos)
                .ThenInclude(c => c.MaintenanceServiceInfo)
                .ThenInclude(c => c.MaintenanceServiceCost)
                .ThenInclude(c => c.MaintenanceService)
                .Include(c => c.Technician)
                .Include(c => c.InformationMaintenance)
                .Where(c => c.InformationMaintenance.InformationMaintenanceId == id && !c.Status.Equals(STATUSENUM.STATUSBOOKING.CANCELLED.ToString()))
                .OrderByDescending(c => c.CreatedDate)
                .ToListAsync();
        }
    }
}
