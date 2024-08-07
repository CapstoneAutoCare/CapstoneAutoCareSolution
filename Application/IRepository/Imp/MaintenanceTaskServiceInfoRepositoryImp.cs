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
    public class MaintenanceTaskServiceInfoRepositoryImp : GenericRepositoryImp<MaintenanceTaskServiceInfo>, IMaintenanceTaskServiceInfoRepository
    {
        public MaintenanceTaskServiceInfoRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<MaintenanceTaskServiceInfo> GetById(Guid id)
        {
            var mtsi = await _context.Set<MaintenanceTaskServiceInfo>()
                            .Include(c => c.MaintenanceTask)
                            .SingleOrDefaultAsync(c => c.MaintenanceTaskServiceInfoId == id);
            if (mtsi == null)
            {
                throw new Exception("Not found MaintenanceTaskServiceInfo");
            }
            return mtsi;
        }

        public async Task<List<MaintenanceTaskServiceInfo>> GetListByActiveAndTask(Guid id)
        {
            return await _context.Set<MaintenanceTaskServiceInfo>()
                .Include(c => c.MaintenanceTask)
                .Where(c => c.MaintenanceTaskId == id && c.Status.Equals(EnumStatus.ACTIVE.ToString()))
                .ToListAsync();
        }
    }
}
