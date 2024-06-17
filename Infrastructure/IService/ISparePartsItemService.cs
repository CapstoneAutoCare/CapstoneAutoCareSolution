using Infrastructure.Common.Request.MaintenanceSchedule;
using Infrastructure.Common.Request.Sparepart;
using Infrastructure.Common.Response.ResponseCost;
using Infrastructure.Common.Response.ResponseServicesCare;
using Infrastructure.Common.Response.ResponseSparePart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface ISparePartsItemService
    {
        Task<List<ResponseSparePartsItem>> GetAll();
        Task<List<ResponseSparePartsItem>> GetListByCenter(Guid centerId);

        Task<ResponseSparePartsItem> GetById(Guid id);
        Task<ResponseSparePartsItem> Create(CreateSparePartsItem create);
        Task<ResponseSparePartsItem> Update(Guid id, UpdateSparePartItem update);
        Task<ResponseSparePartsItem> UpdateStatus(Guid id, string status);

    }
}
