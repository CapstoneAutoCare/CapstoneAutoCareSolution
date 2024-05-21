using Domain.Entities;
using Infrastructure.Common.Request.RequestAccount;
using Infrastructure.Common.Response.ResponseAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface IAdminService
    {
        Task<ResponseAdmin> CreateAdmin(CreateAdmin create);
        Task<ResponseAdmin> UpdateAdmin(Guid adminId,UpdateAdmin update);
        Task<ResponseAdmin> ChangeStatusAdmin(Guid adminId,string status);
        Task<ResponseAdmin> GetByEmail();
        Task<ResponseAdmin> GetById(Guid id);

    }
}
