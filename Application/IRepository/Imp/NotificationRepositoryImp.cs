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
    public class NotificationRepositoryImp : GenericRepositoryImp<Notification>, INotificationRepository
    {
        public NotificationRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<Notification>> GetAll()
        {
            return await _context.Set<Notification>().Include(c => c.Account)
                                 .OrderByDescending(c => c.CreatedDate).ToListAsync();
        }

        public async Task<Notification> GetById(Guid id)
        {
            var n = await _context.Set<Notification>().Include(c => c.Account)
                                 .OrderByDescending(c => c.CreatedDate).FirstOrDefaultAsync(c => c.NotificationId == id);
            if (n == null)
            {
                throw new Exception("Không tìm thấy");
            }
            return n;
        }

        public async Task<List<Notification>> GetListbyAccount(Guid id)
        {
            return await _context.Set<Notification>().Include(c => c.Account)
                //.OrderByDescending(c => c.CreatedDate)
                .Where(c => c.AccountId == id)
                                .OrderByDescending(c => c.CreatedDate)

                .ToListAsync();
        }
    }
}
