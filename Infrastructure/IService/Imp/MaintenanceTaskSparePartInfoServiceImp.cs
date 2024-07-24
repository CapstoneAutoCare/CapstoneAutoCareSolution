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
    public class MaintenanceTaskSparePartInfoServiceImp : IMaintenanceTaskSparePartInfoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MaintenanceTaskSparePartInfoServiceImp(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<ResponseMainTaskSparePart> ChangeStatus(Guid id, string status)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResponseMainTaskSparePart>> Create(CreateMaintenanceTaskSparePartInfo create)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResponseMainTaskSparePart>> GetAll(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseMainTaskSparePart> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
