using Infrastructure.Common.Request.MaintananceServices;
using Infrastructure.Common.Response.ReponseServicesCare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class MaintananceServicesServiceImp : IMaintananceServicesService
    {
        public Task<ResponseMaintananceServices> Create(CreateMaintananceServices create)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResponseMaintananceServices>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseMaintananceServices> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
