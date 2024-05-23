using Infrastructure.Common.Request.Sparepart;
using Infrastructure.Common.Response.ReponseSparePart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class SparePartsItemServiceImp : ISparePartsService
    {
        public Task<ResponseSparePart> Create(CreateSpareParts create)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResponseSparePart>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseSparePart> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
