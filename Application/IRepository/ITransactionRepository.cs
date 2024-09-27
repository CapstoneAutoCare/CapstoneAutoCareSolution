using Application.IGenericRepository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface ITransactionRepository : IGenericRepository<Transactions>
    {
        Task<List<Transactions>> GetAll();
        Task<List<Transactions>> GetListByCenterIdAndStatusTransferred(Guid centerId);
        Task<Transactions> GetById(Guid id);
        Task<List<Transactions>> GetListByClientRECEIVED(Guid clientId);
        Task<Transactions> GetCostByPlanAndVehicleAndCenterWithStatusRECEIVED(Guid plan,Guid vehicle,Guid centerId);
        Task<List<Transactions>> GetTransactionsByVehicleAndCenterAndPlan(Guid plan, Guid vehicle, Guid centerId);
        Task<List<Transactions>> GetListByCenterId(Guid centerId);
    
    }
}
