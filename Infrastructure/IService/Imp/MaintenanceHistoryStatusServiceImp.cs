using AutoMapper;
using Domain.Entities;
using Infrastructure.Common.Request.RequestMaintenanceHistoryStatus;
using Infrastructure.Common.Response.ResponseHistoryStatus;
using Infrastructure.IUnitofWork;


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
            create.Status.ToUpper();
            var mhs = _mapper.Map<MaintenanceHistoryStatus>(create);
            mhs.DateTime = DateTime.Now;
            await _unitOfWork.InformationMaintenance.GetById(mhs.MaintenanceInformationId);
            await _unitOfWork.MaintenanceHistoryStatuses.Add(mhs);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseMaintenanceHistoryStatus>(mhs);
        }

        public async Task Delete(Guid id)
        {
            var mhs = await _unitOfWork.MaintenanceHistoryStatuses.GetById(id);
            await _unitOfWork.MaintenanceHistoryStatuses.Remove(mhs);
            await _unitOfWork.Commit();
        }

        public async Task<List<ResponseMaintenanceHistoryStatus>> GetAll()
        {
            return _mapper.Map<List<ResponseMaintenanceHistoryStatus>>(await _unitOfWork.MaintenanceHistoryStatuses.GetAll());
        }

        public async Task<ResponseMaintenanceHistoryStatus> GetById(Guid id)
        {
            return _mapper.Map<ResponseMaintenanceHistoryStatus>(await _unitOfWork.MaintenanceHistoryStatuses.GetById(id));
        }

        public async Task<ResponseMaintenanceHistoryStatus> Update(Guid id, CreateMaintenanceHistoryStatus update)
        {
            var mhs = await _unitOfWork.MaintenanceHistoryStatuses.GetById(id);
            var updateStatus = _mapper.Map(update, mhs);
            await _unitOfWork.MaintenanceHistoryStatuses.Update(updateStatus);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseMaintenanceHistoryStatus>(updateStatus);
        }
    }
}
