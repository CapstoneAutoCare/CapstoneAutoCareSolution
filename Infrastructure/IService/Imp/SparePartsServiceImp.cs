using Infrastructure.Common.Request.Sparepart;
using Infrastructure.Common.Response.ReponseSparePart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class SparePartsServiceImp : ISparePartsItemService
    {
        public Task<ResponseSparePartsItem> Create(CreateSparePartsItem create)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResponseSparePartsItem>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseSparePartsItem> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
