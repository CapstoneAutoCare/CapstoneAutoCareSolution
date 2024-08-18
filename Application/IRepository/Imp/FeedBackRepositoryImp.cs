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
    public class FeedBackRepositoryImp : GenericRepositoryImp<FeedBack>, IFeedBackRepository
    {
        public FeedBackRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<FeedBack>> GetAll()
        {
            return await _context.Set<FeedBack>()
                .Include(c => c.MaintenanceCenter)
                .Include(c => c.Receipt)
                .ThenInclude(c => c.InformationMaintenance)
                 .ThenInclude(c => c.Booking)
                            .ThenInclude(c => c.Client)
                            .ThenInclude(c=>c.Account)
                .ToListAsync();
        }

        public async Task<FeedBack> GetById(Guid id)
        {
            var feedback = await _context.Set<FeedBack>()
                .Include(c => c.MaintenanceCenter)
                .Include(c => c.Receipt)
                .ThenInclude(c => c.InformationMaintenance)
                 .ThenInclude(c => c.Booking)
                            .ThenInclude(c => c.Client)
                                                        .ThenInclude(c => c.Account)

                .FirstOrDefaultAsync(c => c.FeedBackId == id);
            if (feedback == null)
            {
                throw new Exception("NOT FOUND");
            }
            return feedback;
        }
        public async Task<List<FeedBack>> GetListByCenter(Guid center)
        {
            return await _context.Set<FeedBack>()
                            .Include(c => c.MaintenanceCenter)
                            .Include(c => c.Receipt)
                            //.OrderByDescending(p => p.Vote)
                            .ThenInclude(c => c.InformationMaintenance)
                            .ThenInclude(c=>c.Booking)
                            .ThenInclude(c=>c.Client)
                                                        .ThenInclude(c => c.Account)

                            .Where(c => c.MaintenanceCenterId == center)
                            .ToListAsync();
        }
    }
}
