using AutoMapper;
using Domain.Entities;
using Infrastructure.Common.Request.RequestMaintenanceHistoryStatus;
using Infrastructure.Common.Response.ResponseHistoryStatus;
using Infrastructure.IUnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class MaintenanceHistoryStatusServiceImp : IMaintenanceHistoryStatusService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MaintenanceHistoryStatusServiceImp(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseMaintenanceHistoryStatus> Create(CreateMaintenanceHistoryStatus create)
        {
            var mhs = _mapper.Map<MaintenanceHistoryStatus>(create);
            mhs.DateTime = DateTime.Now;
            await _unitOfWork.InformationMaintenance.GetById(mhs.MaintenanceInformationId);
            return _mapper.Map<ResponseMaintenanceHistoryStatus>(mhs);
        }

        public async Task<List<ResponseMaintenanceHistoryStatus>> GetAll()
        {
            return _mapper.Map<List<ResponseMaintenanceHistoryStatus>>(await _unitOfWork.MaintenanceHistoryStatuses.GetAll());
        }

        public async Task<ResponseMaintenanceHistoryStatus> GetById(Guid id)
        {
            return _mapper.Map<ResponseMaintenanceHistoryStatus>(await _unitOfWork.MaintenanceHistoryStatuses.GetById(id));
        }
    }
}
