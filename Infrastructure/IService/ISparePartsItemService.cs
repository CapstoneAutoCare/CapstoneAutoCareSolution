using Infrastructure.Common.Request.MaintenanceSchedule;
using Infrastructure.Common.Request.Sparepart;
using Infrastructure.Common.Response.ReponseMaintenanceSchedule;
using Infrastructure.Common.Response.ReponseSparePart;
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
        Task<ResponseSparePartsItem> GetById(Guid id);
        Task<ResponseSparePartsItem> Create(CreateSparePartsItem create);
    }
}
