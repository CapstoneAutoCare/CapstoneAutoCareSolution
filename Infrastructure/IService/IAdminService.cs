using Domain.Entities;
using Infrastructure.Common.Request.RequestAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface IAdminService
    {
        Task<Admin> CreateAdmin(CreateAdmin create);
        Task<Admin> UpdateAdmin(Guid adminId,UpdateAdmin update);
        Task<Admin> ChangeStatusAdmin(Guid adminId,string status);

    }
}
