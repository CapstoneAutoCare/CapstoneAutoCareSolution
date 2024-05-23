﻿using Application.IGenericRepository.Imp;
using Domain.Entities;
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

        public Task<List<SparePartsItem>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<SparePartsItem> GetByID(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
