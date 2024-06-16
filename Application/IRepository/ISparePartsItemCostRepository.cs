using Application.IGenericRepository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface ISparePartsItemCostRepository : IGenericRepository<SparePartsItemCost>
    {
        Task<List<SparePartsItemCost>> GetAll();
        Task<SparePartsItemCost> GetById(Guid id);
        Task<List<SparePartsItemCost>> GetListByStatusAndCostStatus(string status, string cost);
    }
}
