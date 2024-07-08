using Infrastructure.Common.Request.RequestAccount;
using Infrastructure.Common.Response.ReponseVehicleModel;
using Infrastructure.Common.Response.ResponseStaffCare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface ICenterService
    {
        Task<ResponseCenter> Create(CreateCenter create);
        Task<List<ResponseCenter>> GetAll();
        Task<ResponseCenter> GetById(Guid id);
        Task<ResponseCenter> Update(Guid id, UpdateCenter center);
    }
}
