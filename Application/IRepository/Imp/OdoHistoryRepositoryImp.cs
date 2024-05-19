using Application.IGenericRepository.Imp;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository.Imp
{
    public class OdoHistoryRepositoryImp : GenericRepositoryImp<OdoHistory>, IOdoHistoryRepository
    {
        public OdoHistoryRepositoryImp(AppDBContext context) : base(context)
        {
        }
    }
}
