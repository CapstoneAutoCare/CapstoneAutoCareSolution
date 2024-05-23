using Infrastructure.Common.Request.MaintananceServices;
using Infrastructure.Common.Request.MaintenanceSchedule;
using Infrastructure.Common.Response.ReponseMaintenanceSchedule;
using Infrastructure.Common.Response.ReponseServicesCare;
using Infrastructure.Common.Response.ReponseSparePart;
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
    }
}
