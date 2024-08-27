using AutoMapper;
using Domain.Entities;
using Domain.Enum;
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

        public async Task<ResponseMainTaskSparePart> ChangeStatus(Guid id, string status)
        {
            var mtspi = await _unitOfWork.MaintenanceTaskSparePartInfo.GetById(id);
            var task = await _unitOfWork.MaintenanceTask.GetById(mtspi.MaintenanceTaskId);
            var mi = await _unitOfWork.InformationMaintenance.GetById(task.InformationMaintenanceId);
            var client = await _unitOfWork.Client.GetById(mi.Booking.ClientId);
            var customercare = await _unitOfWork.CustomerCare.GetById(mi.CustomerCareId);
            var center = await _unitOfWork.MaintenanceCenter.GetById(mi.Booking.MaintenanceCenterId);
            var tech = await _unitOfWork.Techician.GetById(task.TechnicianId);
            if (mtspi.Status == EnumStatus.ACTIVE.ToString()
                && status.Equals(EnumStatus.DONE.ToString()))
            {
                mtspi.Status = EnumStatus.DONE.ToString();
                await _unitOfWork.MaintenanceTaskSparePartInfo.Update(mtspi);

                var checkmtspi = await _unitOfWork.MaintenanceTaskSparePartInfo.GetListByActiveAndTask(mtspi.MaintenanceTaskId);
                var checkmtsi = await _unitOfWork.MaintenanceTaskServiceInfo.GetListByActiveAndTask(mtspi.MaintenanceTaskId);
                if (!checkmtspi.Any(task => task.Status.Equals(EnumStatus.ACTIVE.ToString()))
                    && !checkmtsi.Any(task => task.Status.Equals(EnumStatus.ACTIVE.ToString()))
                    )
                {

                    task.Status = EnumStatus.DONE.ToString();
                    await _unitOfWork.MaintenanceTask.Update(task);
                    mi.FinishedDate = DateTime.Now;

                    MaintenanceHistoryStatus maintenanceHistoryStatus = new MaintenanceHistoryStatus();
                    maintenanceHistoryStatus.Status = EnumStatus.PAYMENT.ToString();
                    maintenanceHistoryStatus.DateTime = DateTime.Now;
                    maintenanceHistoryStatus.Note = EnumStatus.PAYMENT.ToString();
                    maintenanceHistoryStatus.MaintenanceInformationId = task.InformationMaintenanceId;
                    var checkStatus = await _unitOfWork.MaintenanceHistoryStatuses
                          .CheckExistNameByNameAndIdInfor(maintenanceHistoryStatus.MaintenanceInformationId, maintenanceHistoryStatus.Status);
                    if (checkStatus != null)
                    {
                        throw new Exception("History Status existed Status: " + maintenanceHistoryStatus.Status + " Can't Change Status Task :" + status);

                    }
                    mi.Status = EnumStatus.PAYMENT.ToString();
                    await _unitOfWork.MaintenanceHistoryStatuses.Add(maintenanceHistoryStatus);
                    await _unitOfWork.InformationMaintenance.Update(mi);



                    Notification notification = new Notification
                    {
                        AccountId = customercare.AccountId,
                        IsRead = false,
                        CreatedDate = DateTime.Now,
                        NotificationId = Guid.NewGuid(),
                        Title = "Sửa Chữa && Bảo Dưỡng",
                        Message = $"Đã hoàn thành sửa chữa và bảo dưỡng {center.MaintenanceCenterName} vào lúc {maintenanceHistoryStatus.DateTime} và biển số xe là {mi.Booking.Vehicles.LicensePlate}",
                        ReadDate = null,
                        NotificationType = "Hoàn thành sửa chữa"
                    };
                    await _unitOfWork.NotificationRepository.Add(notification);
                    Notification notificationCenter = new Notification
                    {
                        AccountId = center.AccountId,
                        IsRead = false,
                        CreatedDate = DateTime.Now,
                        NotificationId = Guid.NewGuid(),
                        Title = "Sửa Chữa && Bảo Dưỡng",
                        Message = $"Đã hoàn thành sửa chữa và bảo dưỡng {center.MaintenanceCenterName} vào lúc {maintenanceHistoryStatus.DateTime} và biển số xe là {mi.Booking.Vehicles.LicensePlate}",
                        ReadDate = null,
                        NotificationType = "Hoàn thành sửa chữa"
                    };
                    await _unitOfWork.NotificationRepository.Add(notificationCenter);


                    Notification notificationtech = new Notification
                    {
                        AccountId = tech.AccountId,
                        IsRead = false,
                        CreatedDate = DateTime.Now,
                        NotificationId = Guid.NewGuid(),
                        Title = "Sửa Chữa && Bảo Dưỡng",
                        Message = $"Đã hoàn thành sửa chữa và bảo dưỡng tại {center.MaintenanceCenterName} vào lúc {maintenanceHistoryStatus.DateTime} và biển số xe là {mi.Booking.Vehicles.LicensePlate}",
                        ReadDate = null,
                        NotificationType = "Hoàn thành sửa chữa"
                    };

                    Notification notificationclient = new Notification
                    {
                        AccountId = client.AccountId,
                        IsRead = false,
                        CreatedDate = DateTime.Now,
                        NotificationId = Guid.NewGuid(),
                        Title = "Sửa Chữa && Bảo Dưỡng",
                        Message = $"Đã hoàn thành sửa chữa và bảo dưỡng tại {center.MaintenanceCenterName} vào lúc {maintenanceHistoryStatus.DateTime} và biển số xe là {mi.Booking.Vehicles.LicensePlate}",
                        ReadDate = null,
                        NotificationType = "Hoàn thành sửa chữa"
                    };

                    await _unitOfWork.NotificationRepository.Add(notificationclient);


                }
                await _unitOfWork.Commit();
                return _mapper.Map<ResponseMainTaskSparePart>(mtspi);

            }
            else if (mtspi.Status == EnumStatus.ACTIVE.ToString()
                && status.Equals(STATUSENUM.STATUSBOOKING.CANCELLED.ToString()))
            {
                mtspi.Status = STATUSENUM.STATUSBOOKING.CANCELLED.ToString();
                await _unitOfWork.MaintenanceTaskSparePartInfo.Update(mtspi);
                await _unitOfWork.Commit();
                return _mapper.Map<ResponseMainTaskSparePart>(mtspi);

            }
            else
            {
                throw new Exception("Can't Change Status :" + status + "again");
            }
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
