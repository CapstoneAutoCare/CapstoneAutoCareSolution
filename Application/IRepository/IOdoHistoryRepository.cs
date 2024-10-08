﻿using Application.IGenericRepository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IOdoHistoryRepository: IGenericRepository<OdoHistory>
    {
        Task<List<OdoHistory>> GetAll();
        Task<OdoHistory> GetById(Guid id);
        Task<OdoHistory> GetByInforId(Guid inforId);
    }
}
