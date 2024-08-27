using Application.IGenericRepository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface INotificationRepository : IGenericRepository<Notification>
    {
        Task<List<Notification>> GetAll ();
        Task<List<Notification>> GetListbyAccount (Guid id);
        Task<Notification> GetById (Guid id);

    }
}
