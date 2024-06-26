﻿using Application.IGenericRepository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IMaintenanceServiceRepository : IGenericRepository<MaintenanceService>
    {
        Task<List<MaintenanceService>> GetAll();
        Task<MaintenanceService>GetById(Guid? id);
        Task<List<MaintenanceService>> GetListByCenter(Guid center);
    }
}
