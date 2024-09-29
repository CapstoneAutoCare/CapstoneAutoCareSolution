using AutoMapper;
using Domain.Entities;
using Domain.Enum;
using Infrastructure.Common.Request.ReceiptRequest;
using Infrastructure.Common.Response.OdoResponse;
using Infrastructure.Common.Response.ReceiptResponse;
using Infrastructure.ISecurity;
using Infrastructure.IUnitofWork;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Infrastructure.Common.Payment.PayPalSeal;

namespace Infrastructure.IService.Imp
{
    public class ReceiptsServiceImp : IReceiptsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokensHandler _tokensHandler;
        private readonly IConfiguration _configuration;
        public ReceiptsServiceImp(IUnitOfWork unitOfWork, IMapper mapper, ITokensHandler tokensHandler, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokensHandler = tokensHandler;
            _configuration = configuration;
        }

        public async Task<ResponseReceipts> ChangeStatus(Guid id, string status)
        {
            var r = await _unitOfWork.ReceiptRepository.GetById(id);
            var mi = await _unitOfWork.InformationMaintenance.GetById(r.InformationMaintenanceId);
            var customercare = await _unitOfWork.CustomerCare.GetById(mi.CustomerCareId);
            var client = await _unitOfWork.Client.GetById(mi.Booking.ClientId);
            var center = await _unitOfWork.MaintenanceCenter.GetById(mi.Booking.MaintenanceCenterId);
            if (r.Status.Equals(EnumStatus.YETPAID.ToString())
                && status.Equals(EnumStatus.PAID.ToString()))
            {
                r.Status = status;
                mi.Status = status;
                await _unitOfWork.InformationMaintenance.Update(mi);
                await _unitOfWork.ReceiptRepository.Update(r);

                MaintenanceHistoryStatus maintenanceHistoryStatus = new MaintenanceHistoryStatus();
                maintenanceHistoryStatus.Status = EnumStatus.PAID.ToString();
                maintenanceHistoryStatus.DateTime = DateTime.Now;
                maintenanceHistoryStatus.Note = EnumStatus.PAID.ToString();
                maintenanceHistoryStatus.MaintenanceInformationId = mi.InformationMaintenanceId;
                //var checkStatus = await _unitOfWork.MaintenanceHistoryStatuses
                //      .CheckExistNameByNameAndIdInfor(maintenanceHistoryStatus.MaintenanceInformationId, maintenanceHistoryStatus.Status);
                //if (checkStatus == null)
                {
                    await _unitOfWork.MaintenanceHistoryStatuses.Add(maintenanceHistoryStatus);
                }




                Notification notification = new Notification
                {
                    AccountId = customercare.AccountId,
                    IsRead = false,
                    CreatedDate = DateTime.Now,
                    NotificationId = Guid.NewGuid(),
                    Title = "Hoàn Thành Thanh Toán",
                    Message = $"Đã hoàn thành thanh toán tại{center.MaintenanceCenterName} vào lúc {DateTime.Now} và biển số xe là {mi.Booking.Vehicles.LicensePlate}",
                    ReadDate = null,
                    NotificationType = "Hoàn Thành Thanh Toán"
                };
                await _unitOfWork.NotificationRepository.Add(notification);
                Notification notificationCenter = new Notification
                {
                    AccountId = center.AccountId,
                    IsRead = false,
                    CreatedDate = DateTime.Now,
                    NotificationId = Guid.NewGuid(),
                    Title = "Hoàn Thành Thanh Toán",
                    Message = $"Đã hoàn thành thanh toán tại {center.MaintenanceCenterName} vào lúc {DateTime.Now} và biển số xe là {mi.Booking.Vehicles.LicensePlate}",
                    ReadDate = null,
                    NotificationType = "Hoàn Thành Thanh Toán"
                };
                await _unitOfWork.NotificationRepository.Add(notificationCenter);
                Notification notificationclient = new Notification
                {
                    AccountId = client.AccountId,
                    IsRead = false,
                    CreatedDate = DateTime.Now,
                    NotificationId = Guid.NewGuid(),
                    Title = "Hoàn Thành Thanh Toán",
                    Message = $"Đã hoàn thành thanh toán tại {center.MaintenanceCenterName} vào lúc {DateTime.Now} và biển số xe là {mi.Booking.Vehicles.LicensePlate}",
                    ReadDate = null,
                    NotificationType = "Hoàn Thành Thanh Toán"
                };

                await _unitOfWork.NotificationRepository.Add(notificationclient);
                if (mi.MaintenanceVehiclesDetailId != null)
                {
                    var mvd = await _unitOfWork.MaintenanceVehiclesDetailRepository.GetById(mi.MaintenanceVehiclesDetailId); ;
                    mvd.Status = "FINISHED";
                    await _unitOfWork.MaintenanceVehiclesDetailRepository.Update(mvd);

                    var schedule = await _unitOfWork.MaintenanceSchedule.GetByID(mvd.MaintananceScheduleId);
                    var plan = await _unitOfWork.MaintenancePlanRepository.GetById(schedule.MaintenancePlanId);
                    var tran = await _unitOfWork.TransactionRepository
                        .GetTransactionsByVehicleAndCenterAndPlan(plan.MaintenancePlanId, mvd.VehiclesId, mvd.MaintenanceCenterId);
                    var vehicle = await _unitOfWork.Vehicles.GetById(mvd.VehiclesId);
                    var volumTRANSFERRED = _configuration.GetValue<int>("VolTRANSFERRED");

                    if (tran.Any())
                    {
                        var amount = tran.Select(x => x.Amount).First(); // Or use FirstOrDefault() and handle null if necessary
                        Transactions transactions = new Transactions
                        {
                            MaintenancePlanId = plan.MaintenancePlanId,
                            Description = "Đã chuyền tiền từ admin " + vehicle.LicensePlate + " - Mua gói " + plan.MaintenancePlanName + " Số tiền " + amount,
                            Amount = amount * volumTRANSFERRED / 100F,
                            PaymentMethod = "AUTO",
                            MaintenanceCenterId = center.MaintenanceCenterId,
                            Status = "TRANSFERRED",
                            TransactionDate = DateTime.Now,
                            VehiclesId = vehicle.VehiclesId,
                            Volume = 90,
                            TransactionsId = Guid.NewGuid(),
                        };
                        await _unitOfWork.TransactionRepository.Add(transactions);
                    }


                }


                await _unitOfWork.Commit();
                return _mapper.Map<ResponseReceipts>(r);
            }
            else
            {
                throw new Exception("Can't Change Status " + status + " Status has  PAID");

            }

        }

        public async Task<ResponseReceipts> Create(CreateReceipt receipt)
        {
            var r = _mapper.Map<Receipt>(receipt);
            var i = await _unitOfWork.InformationMaintenance.GetById(r.InformationMaintenanceId);
            await _unitOfWork.MaintenanceTask
                .CheckTaskByInforId(i.InformationMaintenanceId,
                EnumStatus.DONE.ToString());
            r.CreatedDate = DateTime.Now;
            r.ReceiptName = "Hóa Đơn Thanh Toán";
            //r.TotalAmount = 0;
            //r.SubTotal = 0;
            r.VAT = _configuration.GetValue<int>("VAT");
            r.SubTotal = i.TotalPrice;
            r.TotalAmount = (float)Math.Round(r.SubTotal * (1 + (r.VAT / 100f)), 0, MidpointRounding.AwayFromZero);
            r.Status = EnumStatus.YETPAID.ToString();
            i.Status = EnumStatus.YETPAID.ToString();


            MaintenanceHistoryStatus maintenanceHistoryStatus = new MaintenanceHistoryStatus();
            maintenanceHistoryStatus.Status = EnumStatus.YETPAID.ToString();
            maintenanceHistoryStatus.DateTime = DateTime.Now;
            maintenanceHistoryStatus.Note = EnumStatus.YETPAID.ToString();
            maintenanceHistoryStatus.MaintenanceInformationId = i.InformationMaintenanceId;
            //var checkStatus = await _unitOfWork.MaintenanceHistoryStatuses
            //      .CheckExistNameByNameAndIdInfor(maintenanceHistoryStatus.MaintenanceInformationId, maintenanceHistoryStatus.Status);
            //if (checkStatus == null)
            {
                await _unitOfWork.MaintenanceHistoryStatuses.Add(maintenanceHistoryStatus);
            }


            await _unitOfWork.InformationMaintenance.Update(i);
            await _unitOfWork.ReceiptRepository.Add(r);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseReceipts>(r);
        }

        public async Task<List<ResponseReceipts>> GetAll()
        {
            return _mapper.Map<List<ResponseReceipts>>(await _unitOfWork.ReceiptRepository.GetAll());
        }

        public async Task<ResponseReceipts> GetById(Guid id)
        {
            return _mapper.Map<ResponseReceipts>(await _unitOfWork.ReceiptRepository.GetById(id));
        }

        public async Task<ResponseReceipts> GetByInforId(Guid id)
        {
            return _mapper.Map<ResponseReceipts>(await _unitOfWork.ReceiptRepository.GetByInfor(id));
        }

        public async Task<List<ResponseReceipts>> GetListByCenter()
        {
            var mail = _tokensHandler.ClaimsFromToken();
            var account = await _unitOfWork.Account.Profile(mail);

            return _mapper.Map<List<ResponseReceipts>>(await _unitOfWork.ReceiptRepository.GetListByCenter(account.MaintenanceCenter.MaintenanceCenterId));
        }

        public async Task<List<ResponseReceipts>> GetListByCenter(Guid id)
        {
            return _mapper.Map<List<ResponseReceipts>>(await _unitOfWork.ReceiptRepository.GetListByCenter(id));
        }

        public async Task<List<ResponseReceipts>> GetListByClient()
        {
            var mail = _tokensHandler.ClaimsFromToken();
            var account = await _unitOfWork.Account.Profile(mail);

            return _mapper.Map<List<ResponseReceipts>>(await _unitOfWork.ReceiptRepository.GetListByClient(account.Client.ClientId));

        }

        public async Task Remove(Guid id)
        {
            var r = await _unitOfWork.ReceiptRepository.GetById(id);
            var i = await _unitOfWork.InformationMaintenance.GetById(r.InformationMaintenanceId);
            //i.Status = EnumStatus.PAYMENT.ToString();
            if (r.Status != EnumStatus.YETPAID.ToString())
            {
                throw new Exception("PAID not Remove");
            }
            //await _unitOfWork.InformationMaintenance.Update(i);
            await _unitOfWork.ReceiptRepository.Remove(r);
            await _unitOfWork.Commit();
        }
    }
}
