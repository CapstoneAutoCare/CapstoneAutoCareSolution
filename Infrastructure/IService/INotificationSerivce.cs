using Domain.Entities;
using Infrastructure.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface INotificationSerivce
    {
        Task<List<ResponseNotification>> GetListbyAccount(Guid id);
        Task<List<ResponseNotification>> GetAll();
        Task<ResponseNotification> UpdateRead(Guid id);
    }
}
