using AutoMapper;
using Domain.Entities;
using Domain.Enum;
using Infrastructure.Common.Request.RequestOdo;
using Infrastructure.Common.Response.OdoResponse;
using Infrastructure.IUnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class OdoHistoryServiceImp : IOdoHistoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OdoHistoryServiceImp(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseOdoHistory> Create(CreateOdoHistory create)
        {
            var odo = _mapper.Map<OdoHistory>(create);
            var ve = await _unitOfWork.Vehicles.GetById(odo.VehiclesId);

            odo.OdoHistoryName = ve.VehicleModel.VehiclesBrand.VehiclesBrandName + " " + ve.VehicleModel.VehicleModelName + " " + ve.LicensePlate + " " + create.Odo.ToString();
            odo.CreatedDate = DateTime.Now;
            odo.Status = EnumStatus.ACTIVE.ToString();
            var i = await _unitOfWork.InformationMaintenance.GetById(odo.MaintenanceInformationId);
            var customercare = await _unitOfWork.CustomerCare.GetById(i.CustomerCareId);
            var center = await _unitOfWork.MaintenanceCenter.GetById(customercare.CenterId);
            var client = await _unitOfWork.Client.GetById(i.Booking.ClientId);
            if (i.Status.Equals(EnumStatus.CHECKIN.ToString())
                || i.Status.Equals(EnumStatus.REPAIRING.ToString()))
            {
                ve.Odo = odo.Odo;
                await _unitOfWork.OdoHistory.Add(odo);
                await _unitOfWork.Vehicles.Update(ve);


                Notification notification = new Notification
                {
                    AccountId = customercare.AccountId,
                    IsRead = false,
                    CreatedDate = DateTime.Now,
                    NotificationId = Guid.NewGuid(),
                    Title = "Sửa Chữa && Bảo Dưỡng",
                    Message = $"Đã lưu odo hiện tại tại {center.MaintenanceCenterName} vào lúc {odo.CreatedDate} và biển số xe là {ve.LicensePlate}",
                    ReadDate = null,
                    NotificationType = "Lưu lịch sử odo hiện tại"
                };
                await _unitOfWork.NotificationRepository.Add(notification);
                Notification notificationCenter = new Notification
                {
                    AccountId = center.AccountId,
                    IsRead = false,
                    CreatedDate = DateTime.Now,
                    NotificationId = Guid.NewGuid(),
                    Title = "Sửa Chữa && Bảo Dưỡng",
                    Message = $"Đã lưu odo hiện tại tại {center.MaintenanceCenterName} vào lúc {odo.CreatedDate} và biển số xe là {ve.LicensePlate}",
                    ReadDate = null,
                    NotificationType = "Lưu lịch sử odo hiện tại"
                };
                await _unitOfWork.NotificationRepository.Add(notificationCenter);



                Notification notificationclient = new Notification
                {
                    AccountId = client.AccountId,
                    IsRead = false,
                    CreatedDate = DateTime.Now,
                    NotificationId = Guid.NewGuid(),
                    Title = "Sửa Chữa && Bảo Dưỡng",
                    Message = $"Đã lưu odo hiện tại tại {center.MaintenanceCenterName} vào lúc {odo.CreatedDate} và biển số xe là {ve.LicensePlate}",
                    ReadDate = null,
                    NotificationType = "Lưu lịch sử odo hiện tại"
                };

                await _unitOfWork.NotificationRepository.Add(notificationclient);





                await _unitOfWork.Commit();
                return _mapper.Map<ResponseOdoHistory>(odo);
            }
            else
            {
                throw new Exception("CAN'T CREATE ODO WITH STATUS " + i.Status);
            }

        }

        public async Task<List<ResponseOdoHistory>> GetAll()
        {
            return _mapper.Map<List<ResponseOdoHistory>>(await _unitOfWork.OdoHistory.GetAll());
        }

        public async Task<ResponseOdoHistory> GetById(Guid id)
        {
            return _mapper.Map<ResponseOdoHistory>(await _unitOfWork.OdoHistory.GetById(id));
        }

        public async Task<ResponseOdoHistory> GetByInforId(Guid id)
        {
            return _mapper.Map<ResponseOdoHistory>(await _unitOfWork.OdoHistory.GetByInforId(id));
        }

        public async Task<ResponseOdoHistory> Update(Guid id, UpdateOdo updateOdo)
        {

            var odo = await _unitOfWork.OdoHistory.GetById(id);
            var vehicle = await _unitOfWork.Vehicles.GetById(odo.VehiclesId);

            var update = _mapper.Map(updateOdo, odo);
            vehicle.Odo = update.Odo;
            await _unitOfWork.OdoHistory.Update(update);
            await _unitOfWork.Vehicles.Update(vehicle);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseOdoHistory>(update);
        }
    }
}
