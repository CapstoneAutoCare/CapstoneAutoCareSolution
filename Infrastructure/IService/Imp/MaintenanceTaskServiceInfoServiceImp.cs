using AutoMapper;
using Infrastructure.Common.Request.RequestMaintenanceTechinican;
using Infrastructure.Common.Response.ResponseTechnicanMain;
using Infrastructure.IUnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class MaintenanceTaskServiceInfoServiceImp : IMaintenanceTaskServiceInfoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Task<ResponseMainTaskService> ChangeStatus(Guid id, string status)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResponseMainTaskService>> Create(CreateMaintenanceTaskServiceInfo create)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResponseMainTaskService>> GetAll(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseMainTaskService> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
