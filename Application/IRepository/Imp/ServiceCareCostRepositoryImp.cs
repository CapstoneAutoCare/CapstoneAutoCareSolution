﻿using Application.IGenericRepository.Imp;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository.Imp
{
    public class ServiceCareCostRepositoryImp : GenericRepositoryImp<MaintenanceService>, IMaintenanceServiceRepository
    {
        public ServiceCareCostRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<MaintenanceService> CheckServiceAdminExistWithCenterId(Guid? serviceadmin, Guid centerId)
        {
            var item = await _context.Set<MaintenanceService>()
                .Include(c => c.MaintenanceCenter)
                .Include(c => c.MaintenanceServiceCosts)
                .Include(c => c.ServiceCare)
                            .ThenInclude(c => c.MaintananceSchedule)
                            .ThenInclude(c => c.VehicleModel)
                            .ThenInclude(c => c.VehiclesBrand)
                .OrderByDescending(p => p.CreatedDate)
                .SingleOrDefaultAsync(c => c.ServiceCareId == serviceadmin && c.MaintenanceCenterId == centerId);
            if (item != null)
            {
                throw new Exception("Dịch vụ này đã được cung cấp từ nhà cung cấp");
            }
            return item;
        }



        public async Task<List<MaintenanceService>> GetAll()
        {
            return await _context.Set<MaintenanceService>()
                .Include(c => c.MaintenanceCenter)
                .Include(c => c.MaintenanceServiceCosts)
                .Include(c => c.ServiceCare)
                            .ThenInclude(c => c.MaintananceSchedule)
                            .ThenInclude(c => c.VehicleModel)
                            .ThenInclude(c => c.VehiclesBrand)
                .OrderByDescending(p => p.CreatedDate)
                .ToListAsync();
        }

        public async Task<MaintenanceService> GetById(Guid? id)
        {
            var ms = await _context.Set<MaintenanceService>()
                .Include(c => c.MaintenanceCenter)
                .Include(c => c.MaintenanceServiceCosts)
                .Include(p => p.ServiceCare)
                            .ThenInclude(c => c.MaintananceSchedule)
                            .ThenInclude(c => c.VehicleModel)
                            .ThenInclude(c => c.VehiclesBrand)
                .OrderByDescending(p => p.CreatedDate)
                .FirstOrDefaultAsync(x => x.MaintenanceServiceId.Equals(id));
            if (ms == null)
            {
                throw new Exception("Not Found");

            }
            return ms;
        }

        public async Task<List<MaintenanceService>> GetListByCenter(Guid center)
        {
            return await _context.Set<MaintenanceService>()
                            .Include(c => c.MaintenanceCenter)
                            .Include(c => c.MaintenanceServiceCosts)
                            .Include(c => c.ServiceCare)
                            .ThenInclude(c => c.MaintananceSchedule)
                            .ThenInclude(c => c.VehicleModel)
                            .ThenInclude(c => c.VehiclesBrand)
                            .OrderByDescending(p => p.CreatedDate)
                            .Include(p => p.ServiceCare)
                            .ThenInclude(c => c.MaintananceSchedule)
                            .Where(c => c.MaintenanceCenterId == center)
                            .ToListAsync();
        }

        public async Task<List<MaintenanceService>> GetListPackageByOdoAndCenterId(Guid centerId, Guid odoId)
        {
            return await _context.Set<MaintenanceService>()
                           .Include(c => c.MaintenanceCenter)
                           .Include(c => c.MaintenanceServiceCosts)
                           .Include(c => c.ServiceCare)
                           .ThenInclude(c => c.MaintananceSchedule)
                           .ThenInclude(c => c.VehicleModel)
                           .ThenInclude(c => c.VehiclesBrand)
                           .OrderByDescending(p => p.CreatedDate)
                           .Include(p => p.ServiceCare)
                           .ThenInclude(c => c.MaintananceSchedule)
                           .Where(c => c.MaintenanceCenterId == centerId
                           && c.ServiceCare.MaintananceScheduleId == odoId && c.Boolean == true)
                           .ToListAsync();
        }

        public async Task<List<MaintenanceService>> GetListPackageByOdoAndCenterIdAndVehicleId(Guid centerId, Guid? odoId, Guid modelvehicleId)
        {
            var i = await _context.Set<MaintenanceService>()
                           .Include(c => c.MaintenanceCenter)
                           .Include(c => c.MaintenanceServiceCosts)
                           .Include(c => c.ServiceCare)
                           .ThenInclude(c => c.MaintananceSchedule)
                           .ThenInclude(c => c.VehicleModel)
                           .ThenInclude(c => c.VehiclesBrand)
                           .OrderByDescending(p => p.CreatedDate)
                           .Include(p => p.ServiceCare)
                           .ThenInclude(c => c.MaintananceSchedule)
                           .Where(c => c.MaintenanceCenterId == centerId
                           && c.ServiceCare.MaintananceScheduleId == odoId && c.Boolean == true && c.VehicleModelId == modelvehicleId)


                           .ToListAsync();
            if (i == null)
            {
                throw new Exception("Trung tâm này không hỗ trợ gói dịch vụ cho xe ");
            }
            return i;
        }

        public async Task<List<MaintenanceService>> GetListPackageOdoTRUEByCenterId(Guid centerId)
        {
            var i = await _context.Set<MaintenanceService>()
                           .Include(c => c.MaintenanceCenter)
                           .Include(c => c.MaintenanceServiceCosts)
                           .Include(c => c.ServiceCare)
                           .ThenInclude(c => c.MaintananceSchedule)
                           .ThenInclude(c => c.VehicleModel)
                           .ThenInclude(c => c.VehiclesBrand)
                           .OrderByDescending(p => p.CreatedDate)
                           .Include(p => p.ServiceCare)
                           .ThenInclude(c => c.MaintananceSchedule)
                           .Where(c => c.MaintenanceCenterId == centerId
                           && c.Boolean == true).ToListAsync();
            return i;
        }
    }
}
