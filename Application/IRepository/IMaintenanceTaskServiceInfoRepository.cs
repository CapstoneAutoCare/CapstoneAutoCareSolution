﻿using Application.IGenericRepository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IMaintenanceTaskServiceInfoRepository : IGenericRepository<MaintenanceTaskServiceInfo>
    {
        Task<List<MaintenanceTaskServiceInfo>> GetListByActiveAndTask(Guid id);
        Task<MaintenanceTaskServiceInfo>GetById(Guid id);
    }
}
