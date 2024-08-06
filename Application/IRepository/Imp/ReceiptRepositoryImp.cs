using Application.IGenericRepository.Imp;
using Domain.Entities;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository.Imp
{
    public class ReceiptRepositoryImp : GenericRepositoryImp<Receipt>, IReceiptRepository
    {
        public ReceiptRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<Receipt>> GetAll()
        {
            return await _context.Set<Receipt>().Include(c => c.InformationMaintenance).ThenInclude(c=>c.Booking).ToListAsync();
        }

        public async Task<Receipt> GetById(Guid id)
        {
            var r = await _context.Set<Receipt>()
                .Include(c => c.InformationMaintenance).ThenInclude(c => c.Booking).Include(c=>c.FeedBack)
                .FirstOrDefaultAsync(c => c.ReceiptId == id);
            if (r == null)
            {
                throw new Exception("Not found");
            }
            return r;
        }

        public async Task<Receipt> GetByInfor(Guid id)
        {
            var r = await _context.Set<Receipt>()
                               .Include(c => c.InformationMaintenance).ThenInclude(c => c.Booking).Include(c => c.FeedBack)

               .FirstOrDefaultAsync(c => c.InformationMaintenanceId == id);
            if (r == null)
            {
                throw new Exception("Not found");
            }
            return r;
        }

        public async Task<List<Receipt>> GetListByCenter(Guid id)
        {
            return await _context.Set<Receipt>()
                                .Include(c => c.InformationMaintenance).ThenInclude(c => c.Booking).Include(c => c.FeedBack)

                .Where(c => c.InformationMaintenance.Booking.MaintenanceCenterId == id).ToListAsync();
        }

        public async Task<List<Receipt>> GetListByClient(Guid id)
        {
            return await _context.Set<Receipt>()
                                            .Include(c => c.InformationMaintenance).ThenInclude(c => c.Booking).Include(c => c.FeedBack)

                            .Where(c => c.InformationMaintenance.Booking.ClientId == id).ToListAsync();
        }

        public async Task<(List<Receipt> Costs, float TotalCost, int Count)> TotalGetListByStatusPaidCenter(Guid centerId)
        {
            var receipt = await _context.Set<Receipt>()
                 .Include(c => c.InformationMaintenance)
                 .Where(c => c.InformationMaintenance.Booking.MaintenanceCenterId == centerId && c.Status.Equals(EnumStatus.PAID.ToString())).ToListAsync();

            var totalCost = receipt.Sum(c => c.TotalAmount);
            int count = receipt.Count;

            return (receipt, totalCost, count);
        }
    }
}
