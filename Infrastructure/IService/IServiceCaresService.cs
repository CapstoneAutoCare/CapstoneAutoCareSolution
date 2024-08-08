using Infrastructure.Common.Request.MaintananceServices;
using Infrastructure.Common.Request.MaintenanceSchedule;
using Infrastructure.Common.Request.Sparepart;
using Infrastructure.Common.Response.ResponseServicesCare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface IServiceCaresService
    {
        Task<List<ResponseServicesCare>> GetAll();
        Task<ResponseServicesCare> GetById(Guid id);
        Task<ResponseServicesCare> Create(CreateServicesCare create);
        Task<ResponseServicesCare> Update(Guid id, UpdateServies update);
        Task<ResponseServicesCare> UpdateStatus(Guid id, string status);
        Task<List<ResponseServicesCare>> GetServiceCaresNotInMaintenanceServices(Guid id);

    }
}
