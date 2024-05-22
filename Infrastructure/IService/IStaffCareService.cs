using Infrastructure.Common.Request.RequestAccount;
using Infrastructure.Common.Response.ResponseStaffCare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface IStaffCareService
    {
        Task<ResponseStaffCare> Create(CreateStaffCare create);
        Task<List<ResponseStaffCare>> GetAll();
        Task<ResponseStaffCare> GetById(Guid id);
    }
}
