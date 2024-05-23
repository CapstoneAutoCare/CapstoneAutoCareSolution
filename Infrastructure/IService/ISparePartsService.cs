using Infrastructure.Common.Request.Sparepart;
using Infrastructure.Common.Response.ReponseSparePart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface ISparePartsService
    {
        Task<List<ResponseSparePart>> GetAll();
        Task<ResponseSparePart> GetById(Guid id);
        Task<ResponseSparePart> Create(CreateSpareParts create);
    }
}
