using AutoMapper;
using Domain.Entities;
using Domain.Enum;
using Infrastructure.Common.Request.MaintananceServices;
using Infrastructure.Common.Request.RequestMaintananceServices;
using Infrastructure.Common.Response.ResponseServicesCare;
using Infrastructure.ISecurity;
using Infrastructure.IUnitofWork;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class MaintananceServicesServiceImp : IMaintananceServicesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokensHandler _tokensHandler;

        public MaintananceServicesServiceImp(IUnitOfWork unitOfWork, IMapper mapper, ITokensHandler tokensHandler)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokensHandler = tokensHandler;
        }

        public async Task<ResponseMaintananceServices> Create(CreateMaintananceServices create)
        {
            var maintanance_services = _mapper.Map<MaintenanceService>(create);
            var email = _tokensHandler.ClaimsFromToken();
            var account = await _unitOfWork.Account.Profile(email);

            maintanance_services.CreatedDate = DateTime.Now;
            maintanance_services.Status = "ACTIVE";
            maintanance_services.Image = null;
            await _unitOfWork.MaintenanceCenter.GetById(account.MaintenanceCenter.MaintenanceCenterId);
            maintanance_services.MaintenanceCenterId = account.MaintenanceCenter.MaintenanceCenterId;
            await _unitOfWork.VehicleModel.GetById(maintanance_services.VehicleModelId);
            await _unitOfWork.MaintenanceService.Add(maintanance_services);

            if (maintanance_services.ServiceCareId == null)
            {
                maintanance_services.Boolean = false;
                await _unitOfWork.Commit();
            }
            return _mapper.Map<ResponseMaintananceServices>(maintanance_services);
        }

        public async Task<List<ResponseMaintananceServices>> CreateList(CreateMainServiceList create)
        {
            var email = _tokensHandler.ClaimsFromToken();
            var account = await _unitOfWork.Account.Profile(email);
            if (create.ServiceCareIds == null || !create.ServiceCareIds.Any())
            {
                throw new Exception("Danh sách dịch vụ bị trống.");
            }
            List<MaintenanceService> list = new List<MaintenanceService>();
            foreach (var item in create.ServiceCareIds)
            {
                var service = await _unitOfWork.ServiceCare.GetByID(item);
                MaintenanceService maintenanceService = new MaintenanceService
                {
                    Boolean = true,
                    CreatedDate = DateTime.Now,
                    Image = service.Image,
                    MaintenanceServiceType = service.ServiceCareType,
                    MaintenanceServiceName = service.ServiceCareName,
                    MaintenanceCenterId = account.MaintenanceCenter.MaintenanceCenterId,
                    ServiceCareId = service.ServiceCareId,
                    Status = service.Status,
                    MaintenanceServiceId = Guid.NewGuid(),
                    VehicleModelId = service.MaintananceSchedule.VehicleModelId,
                };
                await _unitOfWork.MaintenanceService.Add(maintenanceService);
                list.Add(maintenanceService);
                MaintenanceServiceCost serviceCost = new MaintenanceServiceCost
                {
                    MaintenanceServiceCostId = Guid.NewGuid(),
                    ActuralCost = service.OriginalPrice,
                    MaintenanceServiceId = maintenanceService.MaintenanceServiceId,
                    Note = "Đồng bộ với nhà cung cấp",
                    Status = EnumStatus.ACTIVE.ToString(),
                };
                serviceCost.DateTime = DateTime.Now;
                await _unitOfWork.MaintenanceServiceCost.Add(serviceCost);
            }
            await
                _unitOfWork.Commit();
            return _mapper.Map<List<ResponseMaintananceServices>>(list);

        }

        public async Task<List<ResponseMaintananceServices>> GetAll()
        {
            return _mapper.Map<List<ResponseMaintananceServices>>(await _unitOfWork.MaintenanceService.GetAll());
        }

        public async Task<ResponseMaintananceServices> GetById(Guid id)
        {
            var maintanance_services = await _unitOfWork.MaintenanceService.GetById(id);
            return _mapper.Map<ResponseMaintananceServices>(maintanance_services);
        }

        public async Task<List<ResponseMaintananceServices>> GetListByCenter()
        {
            var email = _tokensHandler.ClaimsFromToken();
            var account = await _unitOfWork.Account.Profile(email);
            var list = await _unitOfWork.MaintenanceService.GetListByCenter(account.MaintenanceCenter.MaintenanceCenterId);
            return _mapper.Map<List<ResponseMaintananceServices>>(list);
        }

        public async Task<List<ResponseMaintananceServices>> GetListByCenterId(Guid id)
        {
            var list = await _unitOfWork.MaintenanceService.GetListByCenter(id);
            return _mapper.Map<List<ResponseMaintananceServices>>(list);
        }

        public async Task<List<ResponseMaintananceServices>> GetListPackageAndOdoTRUEByCenterId(Guid id)
        {
            return _mapper.Map<List<ResponseMaintananceServices>>(await _unitOfWork.MaintenanceService.GetListPackageOdoTRUEByCenterId(id));
        }

        public async Task<List<ResponseMaintananceServices>> GetListPackageAndOdoTRUEByCenterIdAndModelId(Guid id, Guid modelId)
        {
            return _mapper.Map<List<ResponseMaintananceServices>>(await _unitOfWork.MaintenanceService.GetListPackageOdoTRUEByCenterIdAndModelId(id, modelId));
        }

        public async Task<List<ResponseMaintananceServices>> GetListPackageByOdoAndCenterId(Guid id, Guid odoId)
        {
            return _mapper.Map<List<ResponseMaintananceServices>>(await _unitOfWork.MaintenanceService.GetListPackageByOdoAndCenterId(id, odoId));
        }

        public async Task Remove(Guid id)
        {
            var u = await _unitOfWork.MaintenanceService.GetById(id);
            await _unitOfWork.MaintenanceService.Remove(u);
            await _unitOfWork.Commit();
        }

        public async Task<List<ResponseMaintananceServices>> Test(Guid id)
        {
            return _mapper.Map<List<ResponseMaintananceServices>>(await _unitOfWork.MaintenanceService.GetListMainSerivceByServiceId(id));
        }

        public async Task<ResponseMaintananceServices> Update(Guid id, UpdateMaintananceServices update)
        {
            var item = await _unitOfWork.MaintenanceService.GetById(id);
            var u = _mapper.Map(update, item);
            await _unitOfWork.MaintenanceService.Update(u);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseMaintananceServices>(u);
        }

        public async Task<ResponseMaintananceServices> UpdateStatus(Guid id, string status)
        {
            var item = await _unitOfWork.MaintenanceService.GetById(id);
            item.Status = status;
            await _unitOfWork.MaintenanceService.Update(item);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseMaintananceServices>(item);
        }
    }
}
