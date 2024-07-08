using Infrastructure.Common.Request.RequestAccount;
using Infrastructure.Common.Response.ResponseCustomerCare;
using Infrastructure.Common.Response.ResponseStaffCare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface ITechnicianService
    {
        Task<ResponseTechnician> Create(CreateTechnician create);
        Task<List<ResponseTechnician>> GetAll();
        Task<List<ResponseTechnician>> GetListByCenter(Guid id);
        Task<ResponseTechnician> GetById(Guid id);
        Task<ResponseTechnician> Update(Guid id, UpdateTechi center);

    }
}
