using AutoMapper;
using Domain.Entities;
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
    public class MaintenanceTechinicanServiceImp : IMaintenanceTechinicanService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MaintenanceTechinicanServiceImp(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseMaintenanceTask> Create(CreateMaintenanceTechinican create)
        {
            var tech = _mapper.Map<MaintenanceTask>(create);
            tech.CreatedDate = DateTime.Now;
            await _unitOfWork.MaintenanceTask.Add(tech);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseMaintenanceTask>(tech);
        }

        public async Task<List<ResponseMaintenanceTask>> GetAll()
        {
            return _mapper.Map<List<ResponseMaintenanceTask>>(await _unitOfWork.MaintenanceTask.GetAll());
        }

        public async Task<ResponseMaintenanceTask> GetById(Guid id)
        {
            return _mapper.Map<ResponseMaintenanceTask>(await _unitOfWork.MaintenanceTask.GetById(id));
        }

        public async Task<ResponseMaintenanceTask> UpdateStatus(Guid id, string status)
        {
            var t = await _unitOfWork.MaintenanceTask.GetById(id);
            t.Status = status;
            await _unitOfWork.MaintenanceTask.Update(t);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseMaintenanceTask>(t);

        }
    }
}
