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
        Task<SparePartsItemCost> GetById(Guid? id);
        Task<SparePartsItemCost> CheckCostVehicleIdAndIdCost(Guid modelVehiclesId, Guid? id);
        Task<List<SparePartsItemCost>> GetListByStatusAndCostStatus(string status, string cost, Guid id);
        Task<(List<SparePartsItemCost> Costs, float TotalCost, int Count)> TotalGetListByStatusAndCostStatus(string status, string cost, Guid id);
        Task<SparePartsItemCost> GetByIdSparePartActive(string status, string cost, Guid id);
        Task<List<SparePartsItemCost>> GetListByDifSparePartAndInforId(string status, string cost, Guid centerId, Guid informationId);

    }
}
