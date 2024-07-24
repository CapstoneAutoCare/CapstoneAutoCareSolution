using Domain.Entities;
using Infrastructure.Common.Request.RequestMaintenanceHistoryStatus;
using Infrastructure.Common.Request.RequestSparePartsItemCost;
using Infrastructure.Common.Response.ResponseCost;
using Infrastructure.Common.Response.ResponseHistoryStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface ISparePartsItemCostService
    {
        Task<List<ResponseSparePartsItemCost>> GetAll();
        Task<List<ResponseSparePartsItemCost>> GetListByVIEWClient(Guid centerId);
        Task<ResponseSparePartsItemCost> GetById(Guid id);
        Task<ResponseSparePartsItemCost> Create(CreateSparePartsItemCost create);
        Task<ResponseSparePartsItemCost> UpdateStatus(Guid id, string status);
        Task<ResponseSparePartsItemCost> GetByIdSparePartActive(Guid id);
        Task<List<ResponseSparePartsItemCost>> GetListByDifSparePartAndInforId(Guid id, Guid inforId);

    }
}
