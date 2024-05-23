using Infrastructure.Common.Request.MaintenancePlan;
using Infrastructure.Common.Response.ReponseMaintenancePlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class MaintenancePlanServiceImp : IMaintenancePlanService
    {
        public Task<ResponseMaintenancePlan> Create(CreateMaintanancePlan create)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResponseMaintenancePlan>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseMaintenancePlan> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
