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
    public class SparePartsCostRepositoryImp : GenericRepositoryImp<SparePartsItem>, ISparePartsItemRepository
    {
        public SparePartsCostRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<SparePartsItem>> GetAll()
        {
            return await _context.Set<SparePartsItem>()
                .Include(c => c.MaintenanceCenter)
                .Include(p => p.SpareParts).ToListAsync();
        }

        public async Task<SparePartsItem> GetById(Guid? id)
        {
            var spi = await _context.Set<SparePartsItem>()
                .Include(p => p.SpareParts)
                .Include(c => c.MaintenanceCenter)
                .FirstOrDefaultAsync(x => x.SparePartsItemtId.Equals(id));
            if (spi == null)
            {
                throw new Exception("Not Found");

            }
            return spi;
        }
    }
}
