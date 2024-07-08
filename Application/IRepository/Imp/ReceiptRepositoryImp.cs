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
    public class ReceiptRepositoryImp : GenericRepositoryImp<Receipt>, IReceiptRepository
    {
        public ReceiptRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<Receipt>> GetAll()
        {
            return await _context.Set<Receipt>().Include(c => c.InformationMaintenance).ToListAsync();
        }

        public async Task<Receipt> GetById(Guid id)
        {
            return await _context.Set<Receipt>().Include(c => c.InformationMaintenance).FirstOrDefaultAsync(c => c.ReceiptId == id);
        }

        public async Task<List<Receipt>> GetListByCenter(Guid id)
        {
            return await _context.Set<Receipt>()
                .Include(c => c.InformationMaintenance)
                .Where(c => c.InformationMaintenance.Booking.MaintenanceCenterId == id).ToListAsync();
        }
    }
}
