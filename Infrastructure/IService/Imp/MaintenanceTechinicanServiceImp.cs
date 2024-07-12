using AutoMapper;
using Domain.Entities;
using Infrastructure.Common.Request.RequestMaintenanceTechinican;
using Infrastructure.Common.Response.ResponseMainInformation;
using Infrastructure.Common.Response.ResponseTechnicanMain;
using Infrastructure.ISecurity;
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
        private readonly ITokensHandler _tokensHandler;

        public MaintenanceTechinicanServiceImp(IUnitOfWork unitOfWork, IMapper mapper, ITokensHandler tokensHandler)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokensHandler = tokensHandler;
        }
            
        public async Task<ResponseMaintenanceTask> Create(CreateMaintenanceTechinican create)
        {
            var tech = _mapper.Map<MaintenanceTask>(create);
            tech.CreatedDate = DateTime.Now;
            tech.Status = "ACTIVE";
            tech.MaintenanceTaskName = "Text";
            var mi = await _unitOfWork.InformationMaintenance.GetById(tech.InformationMaintenanceId);
            var mspi = await _unitOfWork.MaintenanceSparePartInfo.GetListByMainInfor(mi.InformationMaintenanceId);
            await _unitOfWork.MaintenanceTask.Add(tech);
            foreach (var item in mspi)
            {
                MaintenanceTaskSparePartInfo partInfo = new MaintenanceTaskSparePartInfo
                {
                    MaintenanceTaskSparePartInfoId = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    Status = "ACTIVE",
                    MaintenanceTaskId = tech.MaintenanceTaskId,
                    MaintenanceSparePartInfoId = item.MaintenanceSparePartInfoId,
                };
                await _unitOfWork.MaintenanceTaskSparePartInfo.Add(partInfo);
            }
            var msi = await _unitOfWork.MaintenanceServiceInfo.GetListByMainInfor(mi.InformationMaintenanceId);
            foreach (var item in msi)
            {
                MaintenanceTaskServiceInfo partInfo = new MaintenanceTaskServiceInfo
                {
                    MaintenanceTaskServiceInfoId = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    Status = "ACTIVE",
                    MaintenanceTaskId = tech.MaintenanceTaskId,
                    MaintenanceServiceInfoId = item.MaintenanceServiceInfoId,
                };
                await _unitOfWork.MaintenanceTaskServiceInfo.Add(partInfo);
            }
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

        public async Task<List<ResponseMaintenanceTask>> GetListByCenter()
        {
            var email = _tokensHandler.ClaimsFromToken();
            var account = await _unitOfWork.Account.Profile(email);
            return _mapper.Map<List<ResponseMaintenanceTask>>(
                await _unitOfWork.MaintenanceTask.GetListByCenter(account.MaintenanceCenter.MaintenanceCenterId));

        }

        public async Task<List<ResponseMaintenanceTask>> GetListByCustomerCare()
        {
            var email = _tokensHandler.ClaimsFromToken();
            var account = await _unitOfWork.Account.Profile(email);
            return _mapper.Map<List<ResponseMaintenanceTask>>(
                await _unitOfWork.MaintenanceTask.GetListByCustomerCare(account.CustomerCare.CustomerCareId));
        }

        public async Task<List<ResponseMaintenanceTask>> GetListByTechnician()
        {
            var email = _tokensHandler.ClaimsFromToken();
            var account = await _unitOfWork.Account.Profile(email);
            return _mapper.Map<List<ResponseMaintenanceTask>>(
                await _unitOfWork.MaintenanceTask.GetListByTech(account.Technician.TechnicianId));
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
