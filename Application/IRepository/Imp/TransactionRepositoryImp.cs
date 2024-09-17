using Application.IGenericRepository.Imp;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
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
                .FirstOrDefaultAsync(c => c.TransactionsId == id);
            if (transaction == null)
            {
                throw new Exception("Khong tim thay");
            }
            return transaction;
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
                .Where(c => c.MaintenanceCenterId == centerId && c.Status == "TRANSFERRED") .ToListAsync();
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
                .Where(c => c.Vehicles.ClientId == clientId&&c.Status== "RECEIVED").ToListAsync();
        }
    }
}
