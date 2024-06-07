using Infrastructure.Common.Request.MaintananceServices;
using Infrastructure.Common.Request.Sparepart;
using Infrastructure.Common.Response.ReponseSparePart;
using Infrastructure.Common.Response.ResponseMaintenanceService;
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
        Task<ResponseSparePart> Update(Guid id, UpdateSparePart update);
        Task<ResponseSparePart> UpdateStatus(Guid id, string status);
    }
}
