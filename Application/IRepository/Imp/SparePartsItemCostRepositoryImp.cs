﻿using Application.IGenericRepository.Imp;
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
    public class SparePartsItemCostRepositoryImp : GenericRepositoryImp<SparePartsItemCost>, ISparePartsItemCostRepository
    {
        public SparePartsItemCostRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<SparePartsItemCost>> GetAll()
        {
            return await _context.Set<SparePartsItemCost>()
                .Include(c => c.SparePartsItem)
                .OrderByDescending(c => c.DateTime)
                .ToListAsync();
        }

        public async Task<SparePartsItemCost> GetById(Guid? id)
        {
            return await _context.Set<SparePartsItemCost>()
                .Include(c => c.SparePartsItem)
                .Include(c=>c.MaintenanceSparePartInfos)
                .OrderByDescending(c => c.DateTime)
                .FirstOrDefaultAsync(c => c.SparePartsItemCostId == id);
        }


        public async Task<List<SparePartsItemCost>> GetListByStatusAndCostStatus(string status, string cost,Guid id)
        {
            var query = _context.Set<SparePartsItemCost>()
                                .Include(c => c.SparePartsItem)
                                .Include(c => c.MaintenanceSparePartInfos)
                                .OrderByDescending(c => c.DateTime)
                                .Where(c=>c.SparePartsItem.MaintenanceCenterId==id && c.Status.Equals(cost) && c.SparePartsItem.Status.Equals(status));

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
                                         .OrderByDescending(cost => cost.DateTime) // replace SomeProperty with the property to order by
                                         .LastOrDefault())
                            .ToListAsync();

            return spi;
        }

    }
}
