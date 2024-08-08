using Application.IGenericRepository.Imp;
using Domain.Entities;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository.Imp
{
    public class SparePartsItemCostRepositoryImp : GenericRepositoryImp<SparePartsItemCost>, ISparePartsItemCostRepository
    {
        public SparePartsItemCostRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<SparePartsItemCost>> GetAll()
        {
            return await _context.Set<SparePartsItemCost>()
                .Include(c => c.SparePartsItem)
                .ThenInclude(c => c.SpareParts)
                .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                .OrderByDescending(c => c.DateTime)
                .ToListAsync();
        }

        public async Task<SparePartsItemCost> GetById(Guid? id)
        {
            var i = await _context.Set<SparePartsItemCost>()
                .Include(c => c.SparePartsItem)
                .ThenInclude(c => c.SpareParts)
                .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                .Include(c => c.MaintenanceSparePartInfos)
                .OrderByDescending(c => c.DateTime)
                .FirstOrDefaultAsync(c => c.SparePartsItemCostId == id);
            if (i == null)
            {
                throw new Exception("Not Found Id");

            }
            return i;
        }


        public async Task<List<SparePartsItemCost>> GetListByStatusAndCostStatus(string status, string cost, Guid id)
        {
            var query = _context.Set<SparePartsItemCost>()
                                .Include(c => c.SparePartsItem)
                                .ThenInclude(c => c.SpareParts)
                .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                                .Include(c => c.MaintenanceSparePartInfos)
                                .OrderByDescending(c => c.DateTime)
                                .Where(c => c.SparePartsItem.MaintenanceCenterId == id && c.Status.Equals(cost) && c.SparePartsItem.Status.Equals(status));

            var groupedResult = await query
                                      .GroupBy(c => c.SparePartsItemId)
                                      .Select(g => g.OrderByDescending(c => c.DateTime)
                                                    .FirstOrDefault())
                                      .ToListAsync();

            return groupedResult;
        }

        public async Task<List<SparePartsItemCost>> GetListByClientActivea(Guid centerId)
        {
            var spi = await _context.Set<SparePartsItem>()
                            .Include(p => p.SpareParts)
                            .Include(c => c.MaintenanceCenter)
                            .Include(c => c.SparePartsItemCost)
                            .Where(c => c.MaintenanceCenterId == centerId)
                            .Select(c => c.SparePartsItemCost
                                         .Where(cost => cost.Status.Equals(EnumStatus.ACTIVE.ToString()))
                                         .OrderByDescending(cost => cost.DateTime)
                                         .LastOrDefault())
                            .ToListAsync();

            return spi;
        }

        public async Task<SparePartsItemCost> GetByIdSparePartActive(string status, string cost, Guid id)
        {
            var spi = await _context.Set<SparePartsItemCost>()
                        .Include(c => c.SparePartsItem)
                        .ThenInclude(c => c.SpareParts)
                .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                        .Include(c => c.MaintenanceSparePartInfos)
                        .Where(c => c.SparePartsItem.SparePartsItemId == id && c.Status.Equals(cost) && c.SparePartsItem.Status.Equals(status))
                        .OrderByDescending(c => c.DateTime)
                        .FirstOrDefaultAsync();
            return spi;
        }

        public async Task<List<SparePartsItemCost>> GetListByDifSparePartAndInforId(string status, string cost, Guid centerId, Guid informationId)
        {
            var query = _context.Set<SparePartsItemCost>()
                                .Include(c => c.SparePartsItem)
                                .ThenInclude(c => c.SpareParts)
                .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                                .Where(c => c.SparePartsItem.MaintenanceCenterId == centerId
                                         && c.Status.Equals(cost)
                                         && c.SparePartsItem.Status.Equals(status)
                                         && !_context.Set<MaintenanceSparePartInfo>()
                                                     .Any(m => m.SparePartsItemCost.SparePartsItemId == c.SparePartsItemId
                                                            && m.InformationMaintenanceId == informationId))
                                .OrderByDescending(c => c.DateTime);

            var groupedResult = await query
                                      .GroupBy(c => c.SparePartsItemId)
                                      .Select(g => g.OrderByDescending(c => c.DateTime).FirstOrDefault())
                                      .ToListAsync();

            return groupedResult;
        }

        public async Task<(List<SparePartsItemCost> Costs, float TotalCost, int Count)> TotalGetListByStatusAndCostStatus(string status, string cost, Guid id)
        {
            var query = _context.Set<SparePartsItemCost>()
                                .Include(c => c.SparePartsItem)
                                .ThenInclude(c => c.SpareParts)
                .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                                .Include(c => c.MaintenanceSparePartInfos)
                                .OrderByDescending(c => c.DateTime)
                                .Where(c => c.SparePartsItem.MaintenanceCenterId == id && c.Status.Equals(cost) && c.SparePartsItem.Status.Equals(status));

            var groupedResult = await query
                                      .GroupBy(c => c.SparePartsItemId)
                                      .Select(g => g.OrderByDescending(c => c.DateTime)
                                                    .FirstOrDefault())
                                      .ToListAsync();


            var totalCost = groupedResult.Sum(c => c.ActuralCost);
            int count = groupedResult.Count;

            return (groupedResult, totalCost, count);
        }

        public async Task<SparePartsItemCost> CheckCostVehicleIdAndIdCost(Guid vehicleId, Guid? id)
        {
            var c = await _context.Set<SparePartsItemCost>()
                .Include(c => c.SparePartsItem)
                .ThenInclude(c=>c.SpareParts)
                .ThenInclude(c=>c.VehicleModel)
                .ThenInclude(c=>c.VehiclesBrand)
                .Include(c => c.MaintenanceSparePartInfos)
                
                .OrderByDescending(c => c.DateTime)
                .SingleOrDefaultAsync(c => c.SparePartsItemCostId == id
                && c.SparePartsItem.SpareParts.VehicleModelId.Equals(vehicleId));
            if (c == null)
            {
                throw new Exception("This product does not belong to this vehicle");
            }
            return c;
        }
    }
}
