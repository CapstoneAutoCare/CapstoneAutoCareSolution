using Application.IGenericRepository.Imp;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository.Imp
{
    public class TransactionRepositoryImp : GenericRepositoryImp<Transactions>, ITransactionRepository
    {
        public TransactionRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<Transactions>> GetTransactionsByVehicleAndCenterAndPlan(Guid plan, Guid vehicle, Guid centerId)
        {
            var transactions = _context.Transactions
                .Include(c => c.MaintenancePlan)
                .Include(c => c.Vehicles)
                .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                .Include(c => c.Vehicles.Client)
                .ThenInclude(c => c.Account)
                .Include(c => c.MaintenanceCenter)
                .ThenInclude(c => c.Account)
                                .OrderByDescending(c => c.TransactionDate)

            .Where(t => t.VehiclesId == vehicle
                        && t.MaintenanceCenterId == centerId
                        && t.MaintenancePlanId == plan
                        && t.Status == "RECEIVED")
            .ToList();

            // Exclude any transactions with the status "TRANSFERRED"
            var filteredTransactions = transactions
                .Where(t => !_context.Transactions.Any(x => x.VehiclesId == vehicle
                                                           && x.MaintenanceCenterId == centerId
                                                           && x.MaintenancePlanId == plan
                                                           && x.Status == "TRANSFERRED"))
                .ToList();

            return filteredTransactions;
        }

        public async Task<List<Transactions>> GetAll()
        {
            return await _context.Set<Transactions>()
                 .Include(c => c.MaintenancePlan)
                .Include(c => c.Vehicles)
                .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                .Include(c => c.Vehicles.Client)
                .ThenInclude(c => c.Account)
                .Include(c => c.MaintenanceCenter)
                .ThenInclude(c => c.Account)
                .OrderByDescending(c => c.TransactionDate)
                .ToListAsync();
        }

        public async Task<Transactions> GetById(Guid id)
        {
            var transaction = await _context.Set<Transactions>()
                 .Include(c => c.MaintenancePlan)
                .Include(c => c.Vehicles)
                .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                .Include(c => c.Vehicles.Client)
                .ThenInclude(c => c.Account)
                .Include(c => c.MaintenanceCenter)
                .ThenInclude(c => c.Account)
                                .OrderByDescending(c => c.TransactionDate)

                .FirstOrDefaultAsync(c => c.TransactionsId == id);
            if (transaction == null)
            {
                throw new Exception("Khong tim thay");
            }
            return transaction;
        }

        public async Task<Transactions> GetCostByPlanAndVehicleAndCenterWithStatusRECEIVED(Guid plan, Guid vehicle, Guid centerId)
        {
            return await _context.Set<Transactions>()
                 .Include(c => c.MaintenancePlan)
                .Include(c => c.Vehicles)
                .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                .Include(c => c.Vehicles.Client)
                .ThenInclude(c => c.Account)
                .Include(c => c.MaintenanceCenter)
                .ThenInclude(c => c.Account)
                                .OrderByDescending(c => c.TransactionDate)

                .FirstOrDefaultAsync(c => c.MaintenanceCenterId == centerId && c.Status == "RECEIVED" && c.MaintenancePlanId == plan && c.VehiclesId == vehicle);
        }

        public async Task<List<Transactions>> GetListByCenterIdAndStatusTransferred(Guid centerId)
        {
            return await _context.Set<Transactions>()
                 .Include(c => c.MaintenancePlan)
                .Include(c => c.Vehicles)
                .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                .Include(c => c.Vehicles.Client)
                .ThenInclude(c => c.Account)
                .Include(c => c.MaintenanceCenter)
                .ThenInclude(c => c.Account)
                                .OrderByDescending(c => c.TransactionDate)

                .Where(c => c.MaintenanceCenterId == centerId && c.Status == "TRANSFERRED").ToListAsync();
        }

        public async Task<List<Transactions>> GetListByClientRECEIVED(Guid clientId)
        {
            return await _context.Set<Transactions>().Include(c => c.MaintenancePlan)
                .Include(c => c.MaintenancePlan)
                .Include(c => c.Vehicles)
                .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                .Include(c => c.Vehicles.Client)
                .ThenInclude(c => c.Account)
                .Include(c => c.MaintenanceCenter)
                .ThenInclude(c => c.Account)
                                .OrderByDescending(c => c.TransactionDate)

                .Where(c => c.Vehicles.ClientId == clientId && c.Status == "RECEIVED").ToListAsync();
        }

        public async Task<List<Transactions>> GetListByCenterId(Guid centerId)
        {
            return await _context.Set<Transactions>()
                 .Include(c => c.MaintenancePlan)
                .Include(c => c.Vehicles)
                .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehiclesBrand)
                .Include(c => c.Vehicles.Client)
                .ThenInclude(c => c.Account)
                .Include(c => c.MaintenanceCenter)
                .ThenInclude(c => c.Account)
                                .OrderByDescending(c => c.TransactionDate)
                .Where(c => c.MaintenanceCenterId == centerId).ToListAsync();
        }
    }
}
