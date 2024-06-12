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

        public async Task<ResponseMaintenanceTechinican> Create(CreateMaintenanceTechinican create)
        {
            var tech = _mapper.Map<Technician>(create);
            tech.CreatedDate = DateTime.Now;
            await _unitOfWork.Technician.Add(tech);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseMaintenanceTechinican>(tech);
        }

        public async Task<List<ResponseMaintenanceTechinican>> GetAll()
        {
            return _mapper.Map<List<ResponseMaintenanceTechinican>>(await _unitOfWork.Technician.GetAll());
        }

        public async Task<ResponseMaintenanceTechinican> GetById(Guid id)
        {
            return _mapper.Map<ResponseMaintenanceTechinican>(await _unitOfWork.Technician.GetById(id));
        }
    }
}
