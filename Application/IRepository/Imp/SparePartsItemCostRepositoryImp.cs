using Application.IGenericRepository.Imp;
using Domain.Entities;
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

        public Task<List<SparePartsItemCost>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<SparePartsItemCost> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
