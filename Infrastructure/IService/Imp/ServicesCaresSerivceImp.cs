using Infrastructure.Common.Request.MaintananceServices;
using Infrastructure.Common.Response.ReponseServicesCare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class ServicesCaresSerivceImp : IServiceCaresService
    {
        public Task<ResponseServicesCare> Create(CreateServicesCare create)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResponseServicesCare>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseServicesCare> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
