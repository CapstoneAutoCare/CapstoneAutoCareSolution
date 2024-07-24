using Domain.Entities;
using Infrastructure.Common.Request.RequestMaintenanceTechinican;
using Infrastructure.Common.Response.ResponseTechnicanMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface IMaintenanceTaskSparePartInfoService
    {
        Task<ResponseMainTaskSparePart> GetById(Guid id);
        Task<List<ResponseMainTaskSparePart>> GetAll(Guid id);
        Task<List<ResponseMainTaskSparePart>> Create(CreateMaintenanceTaskSparePartInfo create);
        Task<ResponseMainTaskSparePart> ChangeStatus(Guid id, string status);
    }
}
