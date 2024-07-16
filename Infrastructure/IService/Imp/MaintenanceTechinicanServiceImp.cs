using AutoMapper;
using Domain.Entities;
using Domain.Enum;
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
            await _unitOfWork.MaintenanceTask.CheckExistByTechAndInfor(tech.TechnicianId, tech.InformationMaintenanceId);
            if (mi.Status.Equals(STATUSENUM.STATUSMI.CHECKIN.ToString()))
            {
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
                //MaintenanceHistoryStatus maintenanceHistoryStatus = new MaintenanceHistoryStatus();
                //maintenanceHistoryStatus.Status = EnumStatus.REPAIRING.ToString();
                //maintenanceHistoryStatus.DateTime = DateTime.Now;
                //maintenanceHistoryStatus.Note = EnumStatus.REPAIRING.ToString();
                //maintenanceHistoryStatus.MaintenanceInformationId = mi.InformationMaintenanceId;
                //var checkStatus = await _unitOfWork.MaintenanceHistoryStatuses
                //      .CheckExistNameByNameAndIdInfor(maintenanceHistoryStatus.MaintenanceInformationId, maintenanceHistoryStatus.Status);
                //if (checkStatus == null)
                //{
                //    await _unitOfWork.MaintenanceHistoryStatuses.Add(maintenanceHistoryStatus);

                //}
                //mi.Status = STATUSENUM.STATUSMI.REPAIRING.ToString();
                //await _unitOfWork.InformationMaintenance.Update(mi);

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

        public async Task Remove(Guid id)
        {
            var t = await _unitOfWork.MaintenanceTask.GetById(id);
            await _unitOfWork.MaintenanceTask.Remove(t);
            await _unitOfWork.Commit();
        }

        public async Task<ResponseMaintenanceTask> UpdateStatus(Guid id, string status)
        {
            var t = await _unitOfWork.MaintenanceTask.GetById(id);
            if (t.Status.Equals(EnumStatus.ACTIVE.ToString()) && status.Equals(STATUSENUM.STATUSBOOKING.ACCEPT.ToString()))
            {
                t.Status = status;
                MaintenanceHistoryStatus maintenanceHistoryStatus = new MaintenanceHistoryStatus();
                maintenanceHistoryStatus.Status = EnumStatus.REPAIRING.ToString();
                maintenanceHistoryStatus.DateTime = DateTime.Now;
                maintenanceHistoryStatus.Note = EnumStatus.REPAIRING.ToString();
                maintenanceHistoryStatus.MaintenanceInformationId = t.InformationMaintenanceId;
                var checkStatus = await _unitOfWork.MaintenanceHistoryStatuses
                      .CheckExistNameByNameAndIdInfor(maintenanceHistoryStatus.MaintenanceInformationId, maintenanceHistoryStatus.Status);
                if (checkStatus == null)
                {
                    var mi = await _unitOfWork.InformationMaintenance.GetById(t.InformationMaintenanceId);
                    mi.Status = EnumStatus.REPAIRING.ToString();
                    await _unitOfWork.MaintenanceHistoryStatuses.Add(maintenanceHistoryStatus);
                    await _unitOfWork.InformationMaintenance.Update(mi);
                }
            }
            if (t.Status.Equals(EnumStatus.ACTIVE.ToString())
                && status.Equals(STATUSENUM.STATUSBOOKING.CANCEL.ToString()))
            {
                t.Status = STATUSENUM.STATUSBOOKING.CANCEL.ToString();
                var mtsi = await _unitOfWork.MaintenanceTaskServiceInfo.GetListByActiveAndTask(t.MaintenanceTaskId);
                foreach (var i in mtsi)
                {
                    i.Status = EnumStatus.INACTIVE.ToString();
                    await _unitOfWork.MaintenanceTaskServiceInfo.Update(i);

                }
                var mtspi = await _unitOfWork.MaintenanceTaskSparePartInfo.GetListByActiveAndTask(t.MaintenanceTaskId);
                foreach (var i in mtspi)
                {
                    i.Status = EnumStatus.INACTIVE.ToString();
                    await _unitOfWork.MaintenanceTaskSparePartInfo.Update(i);
                }
            }
            await _unitOfWork.MaintenanceTask.Update(t);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseMaintenanceTask>(t);

        }
    }
}
