using Application.IGenericRepository.Imp;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository.Imp
{
    public class MaintenanceServiceCostRepositoryImp : GenericRepositoryImp<MaintenanceServiceCost>, IMaintenanceServiceCostRepository
    {
        public MaintenanceServiceCostRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<MaintenanceServiceCost> CheckCostVehicleIdAndIdCost(Guid modelVehiclesId, Guid? id)
        {
            var i = await _context.Set<MaintenanceServiceCost>()
                .Include(c => c.MaintenanceService)
                .ThenInclude(c => c.ServiceCare)
                .ThenInclude(c => c.MaintananceSchedule)
                .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                .Include(c => c.MaintenanceServiceInfos)
                .FirstOrDefaultAsync(c => c.MaintenanceServiceCostId == id
                && c.MaintenanceService.VehicleModelId.Equals(modelVehiclesId));
            if (i == null)
            {
                throw new Exception("This service does not belong to this vehicle");
            }
            return i;
        }

        public async Task<List<MaintenanceServiceCost>> GetAll()
        {
            return await _context.Set<MaintenanceServiceCost>()
                .Include(c => c.MaintenanceService)
                .ThenInclude(c => c.ServiceCare)
                                .ThenInclude(c => c.MaintananceSchedule)
                .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                .ToListAsync();
        }

        public async Task<MaintenanceServiceCost> GetById(Guid? id)
        {
            var i = await _context.Set<MaintenanceServiceCost>()
                .Include(c => c.MaintenanceService)
                .ThenInclude(c => c.ServiceCare)
                                .ThenInclude(c => c.MaintananceSchedule)
                .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                .Include(c => c.MaintenanceServiceInfos)
                .FirstOrDefaultAsync(c => c.MaintenanceServiceCostId == id);
            if (i == null)
            {
                throw new Exception("Not found Id");
            }
            return i;
        }

        public async Task<MaintenanceServiceCost> GetByIdMaintenanceServiceActive(string status, string cost, Guid id)
        {
            var msc = await _context.Set<MaintenanceServiceCost>()
                        .Include(c => c.MaintenanceService)
                        .ThenInclude(c => c.ServiceCare)
                                .ThenInclude(c => c.MaintananceSchedule)
                .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                        .Include(c => c.MaintenanceServiceInfos)
                        .Where(c => c.MaintenanceServiceId == id && c.Status.Equals(cost) && c.MaintenanceService.Status.Equals(status))
                        .OrderByDescending(c => c.DateTime)
                        .FirstOrDefaultAsync();
            return msc;
        }

        public async Task<MaintenanceServiceCost> GetByIdMaintenanceServiceActiveAndServiceAdmin(string statusserviceadmin, string status, string cost, Guid id)
        {
            var msc = await _context.Set<MaintenanceServiceCost>()
                        .Include(c => c.MaintenanceService)
                        .ThenInclude(c => c.ServiceCare)
                                .ThenInclude(c => c.MaintananceSchedule)
                .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                        .Include(c => c.MaintenanceServiceInfos)
                        .Where(c => c.MaintenanceServiceId == id && c.Status.Equals(cost)
                        && c.MaintenanceService.Status.Equals(status)
                        && c.MaintenanceService.ServiceCare.Status.Equals(statusserviceadmin))
                        .OrderByDescending(c => c.DateTime)
                        .FirstOrDefaultAsync();
            return msc;
        }

        public async Task<List<MaintenanceServiceCost>> GetListByDifMaintenanceServiceAndInforId(string status, string cost, Guid centerId, Guid informationId)
        {
            var query = _context.Set<MaintenanceServiceCost>()
                                .Include(c => c.MaintenanceService)
                                .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                                .Include(c => c.MaintenanceService.ServiceCare)
                                .ThenInclude(c => c.MaintananceSchedule)

                                .Where(c => c.MaintenanceService.MaintenanceCenterId == centerId && c.MaintenanceService.Boolean == false
                                         && c.Status.Equals(cost)
                                         && c.MaintenanceService.Status.Equals(status)
                                         && !_context.Set<MaintenanceServiceInfo>()
                                                     .Any(m => m.MaintenanceServiceCost.MaintenanceServiceId == c.MaintenanceServiceId
                                                            && m.InformationMaintenanceId == informationId))


                                .OrderByDescending(c => c.DateTime);

            var groupedResult = await query
                                      .GroupBy(c => c.MaintenanceServiceId)
                                      .Select(g => g.OrderByDescending(c => c.DateTime).FirstOrDefault())
                                      .ToListAsync();

            return groupedResult;
        }

        public async Task<List<MaintenanceServiceCost>> GetListByStatusAndStatusCost(string status, string coststatus, Guid centerId)
        {
            var query = _context.Set<MaintenanceServiceCost>()
                                .Include(c => c.MaintenanceService)
                                .ThenInclude(c => c.ServiceCare)
                                .ThenInclude(c => c.MaintananceSchedule)
                .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                                .Include(c => c.MaintenanceServiceInfos)
                                .Where(c => c.MaintenanceService.MaintenanceCenterId == centerId && c.Status.Equals(coststatus)
                                && c.MaintenanceService.Status.Equals(status));

            var groupedResult = await query
                                      .GroupBy(c => c.MaintenanceServiceId)
                                      .Select(g => g.OrderByDescending(c => c.DateTime)
                                                    .FirstOrDefault())
                                      .ToListAsync();

            return groupedResult;
        }

        public async Task<List<MaintenanceServiceCost>> GetListCostByMainServiceId(Guid id)
        {
            return await _context.Set<MaintenanceServiceCost>()
                .Include(c => c.MaintenanceService)
                .ThenInclude(c => c.ServiceCare)
                                .ThenInclude(c => c.MaintananceSchedule)
                .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                .Where(c => c.MaintenanceServiceId == id)
                .ToListAsync();
        }

        public async Task<(List<MaintenanceServiceCost> Costs, float TotalCost, int Count)> TotalGetListByStatusAndStatusCost(string status, string coststatus, Guid centerId)
        {
            var query = _context.Set<MaintenanceServiceCost>()
                                .Include(c => c.MaintenanceService)
                                .ThenInclude(c => c.ServiceCare)
                                .ThenInclude(c => c.MaintananceSchedule)
                .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                                .Include(c => c.MaintenanceServiceInfos)
                                .Where(c => c.MaintenanceService.MaintenanceCenterId == centerId && c.Status.Equals(coststatus) && c.MaintenanceService.Status.Equals(status));

            var groupedResult = await query
                                      .GroupBy(c => c.MaintenanceServiceId)
                                      .Select(g => g.OrderByDescending(c => c.DateTime)
                                                    .FirstOrDefault())
                                      .ToListAsync();

            var totalCost = groupedResult.Sum(c => c.ActuralCost);
            int count = groupedResult.Count;

            return (groupedResult, totalCost, count);
        }

    }
}
