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
    public class ImageRepairReceiptRepositoryImp : GenericRepositoryImp<ImageRepairReceipt>, IImageRepairReceiptRepository
    {
        public ImageRepairReceiptRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<ImageRepairReceipt>> GetAll()
        {
            return await _context.Set<ImageRepairReceipt>()
                 .Include(c => c.MaintenanceCenter)
                 .Include(c => c.MaintenanceInformation)
                 .Include(c => c.Vehicle).ToListAsync();
        }

        public async Task<ImageRepairReceipt> GetById(Guid id)
        {
            return await _context.Set<ImageRepairReceipt>()
                             .Include(c => c.MaintenanceCenter)
                             .Include(c => c.MaintenanceInformation)
                             .Include(c => c.Vehicle)
                             .FirstOrDefaultAsync(c => c.ImageRepairReceiptId == id);
        }
    }
}
