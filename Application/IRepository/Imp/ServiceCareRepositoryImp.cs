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
    public class ServiceCareRepositoryImp : GenericRepositoryImp<ServiceCares>, IServiceCareRepository
    {
        public ServiceCareRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<ServiceCares>> GetAll()
        {
            return await _context.Set<ServiceCares>().Include(p => p.MaintananceSchedule).ToListAsync();
        }

        public async Task<ServiceCares> GetByID(Guid? id)
        {
            var service = await _context.Set<ServiceCares>().Include(p => p.MaintananceSchedule).FirstOrDefaultAsync(x => x.ServiceCareId.Equals(id));
            if (service == null)
            {
                throw new Exception("Not Found");

            }
            return service;
        }
    }
}
