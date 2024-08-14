using AutoMapper;
using Domain.Entities;
using Domain.Enum;
using Infrastructure.Common.Request.MaintananceServices;
using Infrastructure.Common.Response.ResponseServicesCare;
using Infrastructure.IUnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class ServicesCaresSerivceImp : IServiceCaresService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ServicesCaresSerivceImp(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseServicesCare> Create(CreateServicesCare create)
        {
            var service = _mapper.Map<ServiceCares>(create);
            await _unitOfWork.MaintenanceSchedule.GetByID(service.MaintananceScheduleId);

            service.CreatedDate = DateTime.Now;
            service.Status = "ACTIVE";

            await _unitOfWork.ServiceCare.Add(service);
            await _unitOfWork.Commit();

            return _mapper.Map<ResponseServicesCare>(service);
        }

        public async Task<List<ResponseServicesCare>> GetAll()
        {
            return _mapper.Map<List<ResponseServicesCare>>(await _unitOfWork.ServiceCare.GetAll());
        }

        public async Task<ResponseServicesCare> GetById(Guid id)
        {
            var maintanance_plan = await _unitOfWork.ServiceCare.GetByID(id);
            return _mapper.Map<ResponseServicesCare>(maintanance_plan);
        }

        public async Task<List<ResponseServicesCare>> GetServiceCaresNotInMaintenanceServices(Guid id)
        {
            return _mapper.Map<List<ResponseServicesCare>>(await _unitOfWork.ServiceCare.GetServiceCaresNotInMaintenanceServices(id));
        }

        public async Task<ResponseServicesCare> Update(Guid id, UpdateServies update)
        {
            var item = await _unitOfWork.ServiceCare.GetByID(id);
            var service = _mapper.Map(update, item);
            await _unitOfWork.ServiceCare.Update(service);
            //if (item.OriginalPrice != update.OriginalPrice)
            //{
            item.OriginalPrice = update.OriginalPrice;
            var ms = await _unitOfWork.MaintenanceService.GetListMainSerivceByServiceId(item.ServiceCareId);
            //if (ms != null)
            //{
            foreach (var m in ms)
            {
                MaintenanceServiceCost cost = new MaintenanceServiceCost
                {
                    ActuralCost = item.OriginalPrice,
                    DateTime = DateTime.Now,
                    MaintenanceServiceId = m.MaintenanceServiceId,
                    Note = "Giá mới được cập nhật từ nhà cung cấp",
                    Status = EnumStatus.INACTIVE.ToString(),
                    MaintenanceServiceCostId = Guid.NewGuid(),

                };
                m.Image = service.Image;
                
                await _unitOfWork.MaintenanceService.Update(m);
                await _unitOfWork.MaintenanceServiceCost.Add(cost);
                //}
                //}

            }


            await _unitOfWork.Commit();
            return _mapper.Map<ResponseServicesCare>(item);
        }

        public async Task<ResponseServicesCare> UpdateStatus(Guid id, string status)
        {
            var item = await _unitOfWork.ServiceCare.GetByID(id);
            item.Status = status;
            await _unitOfWork.ServiceCare.Update(item);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseServicesCare>(item);
        }
    }
}
