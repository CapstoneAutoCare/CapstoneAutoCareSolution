using Application.Dashboard;
using AutoMapper;
using Domain.Entities;
using Domain.Enum;
using Infrastructure.Common.Request.RequestMaintenanceInformation;
using Infrastructure.Common.Response.ResponseBooking;
using Infrastructure.Common.Response.ResponseMainInformation;
using Infrastructure.ISecurity;
using Infrastructure.IUnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class MaintenanceInformationServiceImp : IMaintenanceInformationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokensHandler _tokensHandler;

        public MaintenanceInformationServiceImp(IUnitOfWork unitOfWork, IMapper mapper, ITokensHandler tokensHandler)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokensHandler = tokensHandler;
        }

        public async Task<ResponseMaintenanceInformation> Create(CreateMaintenanceInformation create)
        {
            var mi = _mapper.Map<MaintenanceInformation>(create);
            //var email = _tokensHandler.ClaimsFromToken();
            //mi.CreatedDate = DateTime.Now;
            //var account = await _unitOfWork.Account.Profile(email);
            var customercare = await _unitOfWork.CustomerCare.GetById(mi.CustomerCareId);
            mi.CustomerCareId = customercare.CustomerCareId;

            if (mi.BookingId == null)
            {
                await _unitOfWork.InformationMaintenance.Add(mi);
                await _unitOfWork.Commit();
                return _mapper.Map<ResponseMaintenanceInformation>(mi);
            }
            else
            {
                var booking = await _unitOfWork.Booking.GetById(mi.BookingId);
                booking.Status = STATUSENUM.STATUSBOOKING.ACCEPTED.ToString();
                await _unitOfWork.InformationMaintenance.Add(mi);
                await _unitOfWork.Booking.Update(booking);
                await _unitOfWork.Commit();
                return _mapper.Map<ResponseMaintenanceInformation>(mi);
            }
        }

        public async Task<ResponseMaintenanceInformation> CreateHaveItems(CreateMaintenanceInformationHaveItems create)
        {
            var mi = MapAndInitializeMaintenanceInformation(create);
            //var email = _tokensHandler.ClaimsFromToken();
            //var account = await _unitOfWork.Account.Profile(email);
            var customercare = await _unitOfWork.CustomerCare.GetById(mi.CustomerCareId);
            mi.CustomerCareId = customercare.CustomerCareId;

            var doublePrice = await ProcessSparePartInfos(mi.MaintenanceSparePartInfos, mi.InformationMaintenanceId, mi.TotalPrice);
            mi.TotalPrice = doublePrice;

            await ProcessServiceInfos(mi.MaintenanceServiceInfos, mi.InformationMaintenanceId, mi.TotalPrice);

            if (mi.BookingId == null)
            {
                return await HandleNullBookingId(mi);

            }
            return await HandleNonNullBookingId(mi);
        }

        public async Task<List<ResponseMaintenanceInformation>> GetAll()
        {
            return _mapper.Map<List<ResponseMaintenanceInformation>>(await _unitOfWork.InformationMaintenance.GetAll());
        }

        public async Task<ResponseMaintenanceInformation> GetById(Guid id)
        {
            return _mapper.Map<ResponseMaintenanceInformation>(await _unitOfWork.InformationMaintenance.GetById(id));
        }

        private async Task<float> ProcessSparePartInfos(IEnumerable<MaintenanceSparePartInfo> sparePartInfos, Guid maintenanceId, float price)
        {
            if (sparePartInfos.Any())
            {
                foreach (var i in sparePartInfos)
                {
                    var sp = _mapper.Map<MaintenanceSparePartInfo>(i);
                    if (sp.SparePartsItemCostId == null)
                    {
                        throw new Exception("Require add Product in Center Cost");
                    }
                    sp.Status = EnumStatus.ACTIVE.ToString();
                    sp.CreatedDate = DateTime.Now;
                    sp.Discount = 0;
                    sp.TotalCost = (sp.ActualCost * sp.Quantity) * (1 - (sp.Discount / 100f));
                    sp.InformationMaintenanceId = maintenanceId;
                    await _unitOfWork.SparePartsItemCost.GetById(sp.SparePartsItemCostId);
                    //await _unitOfWork.SparePartsItem.GetByStatusAndCostActive(sp.SparePartsItemId);
                    price = sp.TotalCost + i.TotalCost;

                    await _unitOfWork.MaintenanceSparePartInfo.Add(sp);
                }
            }
            return price;
        }

        private async Task<float> ProcessServiceInfos(IEnumerable<MaintenanceServiceInfo> serviceInfos, Guid maintenanceId, float price)
        {
            if (serviceInfos.Any())
            {
                foreach (var i in serviceInfos)
                {
                    var msi = _mapper.Map<MaintenanceServiceInfo>(i);
                    if (msi.MaintenanceServiceCostId == null)
                    {
                        throw new Exception("Require add Product in Center");
                    }
                    msi.Status = EnumStatus.ACTIVE.ToString();
                    msi.CreatedDate = DateTime.Now;
                    msi.Discount = 0;
                    msi.TotalCost = (msi.ActualCost * msi.Quantity) * (1 - (msi.Discount / 100f));
                    msi.InformationMaintenanceId = maintenanceId;
                    await _unitOfWork.MaintenanceServiceCost.GetById(msi.MaintenanceServiceCostId);
                    await _unitOfWork.MaintenanceServiceInfo.Add(msi);
                }
            }
            return price;
        }
        private MaintenanceInformation MapAndInitializeMaintenanceInformation(CreateMaintenanceInformationHaveItems create)
        {
            var mi = _mapper.Map<MaintenanceInformation>(create);
            mi.CreatedDate = DateTime.Now;
            mi.TotalPrice = 0;
            mi.Status = EnumStatus.CHECKIN.ToString();



            return mi;
        }

        private async Task<ResponseMaintenanceInformation> HandleNullBookingId(MaintenanceInformation mi)
        {
            await _unitOfWork.InformationMaintenance.Add(mi);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseMaintenanceInformation>(mi);
        }

        private async Task<ResponseMaintenanceInformation> HandleNonNullBookingId(MaintenanceInformation mi)
        {
            var booking = await _unitOfWork.Booking.GetById(mi.BookingId);
            booking.Status = STATUSENUM.STATUSBOOKING.ACCEPTED.ToString();

            var listmainbybooking = await _unitOfWork.InformationMaintenance.GetListByBookingId(booking.BookingId);

            if (!listmainbybooking.All(c => c.Status.Equals(STATUSENUM.STATUSBOOKING.CANCELLED.ToString())))
            {
                throw new Exception("Booking này không thể add thêm maininfor được");
            }


            await _unitOfWork.InformationMaintenance.Add(mi);
            MaintenanceHistoryStatus historyStatus = new MaintenanceHistoryStatus
            {
                MaintenanceHistoryStatusId = Guid.NewGuid(),
                Status = EnumStatus.CREATEDBYClIENT.ToString(),
                DateTime = booking.CreatedDate,
                MaintenanceInformationId = mi.InformationMaintenanceId,
                Note = mi.Note,
            };
            await _unitOfWork.MaintenanceHistoryStatuses.Add(historyStatus);

            MaintenanceHistoryStatus historyStatuscheckin = new MaintenanceHistoryStatus
            {
                MaintenanceHistoryStatusId = Guid.NewGuid(),
                Status = EnumStatus.CHECKIN.ToString(),
                DateTime = DateTime.Now,
                MaintenanceInformationId = mi.InformationMaintenanceId,
                Note = mi.Note,
            };
            await _unitOfWork.MaintenanceHistoryStatuses.Add(historyStatuscheckin);




            await _unitOfWork.Booking.Update(booking);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseMaintenanceInformation>(mi);
        }

        public async Task<List<ResponseMaintenanceInformation>> GetListByClient()
        {
            var email = _tokensHandler.ClaimsFromToken();
            var account = await _unitOfWork.Account.Profile(email);
            return _mapper.Map<List<ResponseMaintenanceInformation>>(
                await _unitOfWork.InformationMaintenance.GetListByClient(account.Client.ClientId));

        }

        public async Task<List<ResponseMaintenanceInformation>> GetListByCenter()
        {
            var email = _tokensHandler.ClaimsFromToken();
            var account = await _unitOfWork.Account.Profile(email);
            return _mapper.Map<List<ResponseMaintenanceInformation>>(
                await _unitOfWork.InformationMaintenance.GetListByCenter(account.MaintenanceCenter.MaintenanceCenterId));
        }

        public async Task Remove(Guid id)
        {
            var re = await _unitOfWork.InformationMaintenance.GetById(id);
            await _unitOfWork.InformationMaintenance.Remove(re);
        }

        public async Task<ResponseMaintenanceInformation> ChangeStatus(Guid id, string status)
        {
            var re = await _unitOfWork.InformationMaintenance.GetById(id);
            var center = await _unitOfWork.MaintenanceCenter.GetById(re.CustomerCare.CenterId);
            var client = await _unitOfWork.Client.GetById(re.Booking.ClientId);
            var customercare = await _unitOfWork.CustomerCare.GetById(re.CustomerCareId);
            //re.Status = status;
            if (re.Status.Equals(STATUSENUM.STATUSMI.WAITINGBYCAR.ToString()) && status.Equals(STATUSENUM.STATUSMI.CHECKIN.ToString()))
            {

                MaintenanceHistoryStatus maintenanceHistoryStatus = new MaintenanceHistoryStatus();
                maintenanceHistoryStatus.Status = EnumStatus.CHECKIN.ToString();
                maintenanceHistoryStatus.DateTime = DateTime.Now;
                maintenanceHistoryStatus.Note = EnumStatus.CHECKIN.ToString();
                maintenanceHistoryStatus.MaintenanceInformationId = re.InformationMaintenanceId;
                var checkStatus = await _unitOfWork.MaintenanceHistoryStatuses
                      .CheckExistNameByNameAndIdInfor(maintenanceHistoryStatus.MaintenanceInformationId, maintenanceHistoryStatus.Status);
                if (checkStatus == null)
                {
                    await _unitOfWork.MaintenanceHistoryStatuses.Add(maintenanceHistoryStatus);
                }
                re.Status = status;
                await _unitOfWork.InformationMaintenance.Update(re);


                Notification notification = new Notification
                {
                    AccountId = client.AccountId,
                    IsRead = false,
                    CreatedDate = DateTime.Now,
                    NotificationId = Guid.NewGuid(),
                    Title = "Đặt Lịch Bảo Dưỡng",
                    Message = $"Đã nhận xe tại {center.MaintenanceCenterName} vào lúc {re.Booking.BookingDate} và biển số xe là {re.Booking.Vehicles.LicensePlate}",
                    ReadDate = null,
                    NotificationType = "Đặt lịch"
                };
                await _unitOfWork.NotificationRepository.Add(notification);
                Notification notificationCenter = new Notification
                {
                    AccountId = center.AccountId,
                    IsRead = false,
                    CreatedDate = DateTime.Now,
                    NotificationId = Guid.NewGuid(),
                    Title = "Đặt Lịch Bảo Dưỡng",
                    Message = $"Đã nhận xe bảo dưỡng tại {center.MaintenanceCenterName} vào lúc {re.Booking.BookingDate} và biển số xe là {re.Booking.Vehicles.LicensePlate}",
                    ReadDate = null,
                    NotificationType = "Đặt lịch"
                };
                await _unitOfWork.NotificationRepository.Add(notificationCenter);

                Notification notificationCustomerCare = new Notification
                {
                    AccountId = customercare.AccountId,
                    IsRead = false,
                    CreatedDate = DateTime.Now,
                    NotificationId = Guid.NewGuid(),
                    Title = "Đặt Lịch Bảo Dưỡng",
                    Message = $"Đã nhận xe bảo dưỡng tại {center.MaintenanceCenterName} vào lúc {re.Booking.BookingDate} và biển số xe là {re.Booking.Vehicles.LicensePlate}",
                    ReadDate = null,
                    NotificationType = "Đặt lịch"
                };
                await _unitOfWork.NotificationRepository.Add(notificationCustomerCare);


                await _unitOfWork.Commit();

                return _mapper.Map<ResponseMaintenanceInformation>(re);
            }
            else if (re.Status.Equals(STATUSENUM.STATUSMI.WAITINGBYCAR.ToString()) && status.Equals(STATUSENUM.STATUSBOOKING.CANCELLED.ToString()))
            {
                MaintenanceHistoryStatus maintenanceHistoryStatus = new MaintenanceHistoryStatus();
                maintenanceHistoryStatus.Status = STATUSENUM.STATUSBOOKING.CANCELLED.ToString();
                maintenanceHistoryStatus.DateTime = DateTime.Now;
                maintenanceHistoryStatus.Note = STATUSENUM.STATUSBOOKING.CANCELLED.ToString();
                maintenanceHistoryStatus.MaintenanceInformationId = re.InformationMaintenanceId;
                var checkStatus = await _unitOfWork.MaintenanceHistoryStatuses
                      .CheckExistNameByNameAndIdInfor(maintenanceHistoryStatus.MaintenanceInformationId, maintenanceHistoryStatus.Status);
                if (checkStatus == null)
                {
                    await _unitOfWork.MaintenanceHistoryStatuses.Add(maintenanceHistoryStatus);
                }
                re.Status = status;
                var booking = await _unitOfWork.Booking.GetById(re.BookingId);
                booking.Status = status;
                re.FinishedDate = DateTime.Now;

                await _unitOfWork.Booking.Update(booking);
                await _unitOfWork.InformationMaintenance.Update(re);
                await _unitOfWork.Commit();

                return _mapper.Map<ResponseMaintenanceInformation>(re);
            }
            else if (re.Status.Equals(STATUSENUM.STATUSMI.CHECKIN.ToString()) && status.Equals(STATUSENUM.STATUSBOOKING.CHANGEPACKAGE.ToString()))
            {
                MaintenanceHistoryStatus maintenanceHistoryStatus = new MaintenanceHistoryStatus();
                maintenanceHistoryStatus.Status = STATUSENUM.STATUSBOOKING.CANCELLED.ToString();
                maintenanceHistoryStatus.DateTime = DateTime.Now;
                maintenanceHistoryStatus.Note = STATUSENUM.STATUSBOOKING.CANCELLED.ToString();
                maintenanceHistoryStatus.MaintenanceInformationId = re.InformationMaintenanceId;
                var checkStatus = await _unitOfWork.MaintenanceHistoryStatuses
                      .CheckExistNameByNameAndIdInfor(maintenanceHistoryStatus.MaintenanceInformationId, maintenanceHistoryStatus.Status);
                if (checkStatus == null)
                {
                    await _unitOfWork.MaintenanceHistoryStatuses.Add(maintenanceHistoryStatus);
                }
                re.Status = STATUSENUM.STATUSBOOKING.CANCELLED.ToString();
                //var booking = await _unitOfWork.Booking.GetById(re.BookingId);
                //booking.Status = status;
                //await _unitOfWork.Booking.Update(booking);
                if (re.MaintenanceVehiclesDetailId != null)
                {
                    var mvd = await _unitOfWork.MaintenanceVehiclesDetailRepository.GetById(re.MaintenanceVehiclesDetailId);
                    mvd.Status = "EXPIRED";
                    await _unitOfWork.MaintenanceVehiclesDetailRepository.Update(mvd);
                }
                re.FinishedDate = DateTime.Now;
                await _unitOfWork.InformationMaintenance.Update(re);
                await _unitOfWork.Commit();

                return _mapper.Map<ResponseMaintenanceInformation>(re);
            }


            else
            {
                throw new Exception("Không thay đổi Status được nữa");
            }

        }

        public async Task<ResponseMaintenanceInformation> ChangeStatusBackUp(Guid id, string status)
        {
            var re = await _unitOfWork.InformationMaintenance.GetById(id);
            re.Status = status;
            await _unitOfWork.InformationMaintenance.Update(re);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseMaintenanceInformation>(re);

        }

        public async Task<List<ResponseMaintenanceInformation>> GetListByCenterAnd(string status)
        {
            var email = _tokensHandler.ClaimsFromToken();
            var account = await _unitOfWork.Account.Profile(email);
            return _mapper.Map<List<ResponseMaintenanceInformation>>(
                await _unitOfWork.InformationMaintenance.GetListByCenterAndStatus(account.MaintenanceCenter.MaintenanceCenterId, status));
        }

        public async Task<List<ResponseMaintenanceInformation>> GetListByCenterAndStatusCheckinAndTaskInactive(Guid centerId)
        {
            //var email = _tokensHandler.ClaimsFromToken();
            //var account = await _unitOfWork.Account.Profile(email);
            return _mapper.Map<List<ResponseMaintenanceInformation>>(
                await _unitOfWork.InformationMaintenance.GetListByCenterAndStatusCheckinAndTaskInactive(centerId));

        }

        public async Task<List<ResponseMaintenanceInformation>> GetListByBookingId(Guid id)
        {
            return _mapper.Map<List<ResponseMaintenanceInformation>>(
                            await _unitOfWork.InformationMaintenance.GetListByBookingId(id));
        }

        public async Task<List<ResponseMaintenanceInformation>> GetListByCenterId(Guid id)
        {
            return _mapper.Map<List<ResponseMaintenanceInformation>>(
                             await _unitOfWork.InformationMaintenance.GetListByCenter(id));
        }

        public async Task<List<MonthlyRevenue>> GetMonthlyRevenue(int year, Guid id)
        {
            return _mapper.Map<List<MonthlyRevenue>>(
                             await _unitOfWork.InformationMaintenance.GetMonthlyRevenue(year, id));
        }

        public async Task<List<MonthlyBookingSummary>> GetMonthlyRevenuePAID(int year, Guid id)
        {
            return _mapper.Map<List<MonthlyBookingSummary>>(
                                        await _unitOfWork.InformationMaintenance.GetInforPAIDByMonthInYearByCenterId(id, year));
        }

        public async Task<ResponseMaintenanceInformation> CreateMaintenance(CreateMaintenanceInformationHavePackage create)
        {
            var mi = _mapper.Map<MaintenanceInformation>(create);
            mi.TotalPrice = 0;
            mi.Status = EnumStatus.CHECKIN.ToString();
            mi.CreatedDate = DateTime.Now;
            mi.FinishedDate = null;

            await _unitOfWork.CustomerCare.GetById(mi.CustomerCareId);
            var booking = await _unitOfWork.Booking.GetById(mi.BookingId);
            var vehicle = await _unitOfWork.Vehicles.GetById(booking.VehicleId);
            var mvd = await _unitOfWork.MaintenanceVehiclesDetailRepository.GetById(mi.MaintenanceVehiclesDetailId);

            var listservice = await _unitOfWork.MaintenanceService
                .GetListPackageByOdoAndCenterIdAndVehicleId(booking.MaintenanceCenterId, mvd.MaintananceScheduleId, vehicle.VehicleModelId);

            await _unitOfWork.InformationMaintenance.Add(mi);
            foreach (var itemcost in listservice)
            {
                var cost = await _unitOfWork.MaintenanceServiceCost.GetByIdMaintenanceServiceActiveAndServiceAdmin
                    (EnumStatus.ACTIVE.ToString(), EnumStatus.ACTIVE.ToString(), EnumStatus.ACTIVE.ToString(), itemcost.MaintenanceServiceId);
                MaintenanceServiceInfo info = new MaintenanceServiceInfo
                {
                    InformationMaintenanceId = mi.InformationMaintenanceId,
                    ActualCost = cost.ActuralCost,
                    Discount = 0,
                    CreatedDate = DateTime.Now,
                    Note = "Không tính tiền",
                    Quantity = 1,
                    Status = EnumStatus.ACTIVE.ToString(),
                    TotalCost = (0 * 1) * (1 - (0) / 100f),
                    MaintenanceServiceCostId = cost.MaintenanceServiceCostId,
                    MaintenanceServiceInfoId = Guid.NewGuid(),
                    MaintenanceServiceInfoName = cost.MaintenanceService.MaintenanceServiceName,
                };
                await _unitOfWork.MaintenanceServiceInfo.Add(info);
            }
            MaintenanceHistoryStatus maintenanceHistoryStatus = new MaintenanceHistoryStatus();
            maintenanceHistoryStatus.Status = EnumStatus.CHECKIN.ToString();
            maintenanceHistoryStatus.DateTime = DateTime.Now;
            maintenanceHistoryStatus.Note = EnumStatus.CHECKIN.ToString();
            maintenanceHistoryStatus.MaintenanceInformationId = mi.InformationMaintenanceId;
            await _unitOfWork.MaintenanceHistoryStatuses.Add(maintenanceHistoryStatus);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseMaintenanceInformation>(mi);

        }

        public async Task<ResponseMaintenanceInformation> GetByBookingIdAndScheduleIdAndVehicleId(Guid booking, Guid schedule, Guid vehicleId)
        {
            return _mapper.Map<ResponseMaintenanceInformation>(await _unitOfWork.InformationMaintenance.GetByBookingIdAndScheduleId(booking, schedule, vehicleId));
        }

        public async Task<ResponseMaintenanceInformation> GetByMVDId(Guid id)
        {
            return _mapper.Map<ResponseMaintenanceInformation>(await _unitOfWork.InformationMaintenance.GetByMVDId(id));
        }

        public async Task<ResponseMaintenanceInformation> CreateMainV1(CreateMainV1 createMainV1)
        {
            var main = await _unitOfWork.InformationMaintenance.GetById(createMainV1.InformationMaintenanceId);
            var booking = await _unitOfWork.Booking.GetById(createMainV1.BookingId);
            var customercare = await _unitOfWork.CustomerCare.GetById(createMainV1.CustomerCareId);
            if (customercare.CenterId != booking.MaintenanceCenterId)
            {
                throw new Exception("Không cùng trung tâm");
            }
            var mvd = await _unitOfWork.MaintenanceVehiclesDetailRepository.GetById(main.MaintenanceVehiclesDetailId);
            var schedule = await _unitOfWork.MaintenanceSchedule.GetByID(mvd.MaintananceScheduleId);
            if (schedule.MaintenancePlanId != booking.MaintenancePlanId)
            {
                throw new Exception("Gói này không phù hợp");
            }
            if (booking.Status == STATUSENUM.STATUSBOOKING.ACCEPTED.ToString())
            {
                main.BookingId = booking.BookingId;
                main.CustomerCareId = customercare.CustomerCareId;
                main.Note = createMainV1.Note;
                main.Status = EnumStatus.CHECKIN.ToString();

                MaintenanceHistoryStatus maintenanceHistoryStatus = new MaintenanceHistoryStatus();
                maintenanceHistoryStatus.Status = EnumStatus.CHECKIN.ToString();
                maintenanceHistoryStatus.DateTime = DateTime.Now;
                maintenanceHistoryStatus.Note = EnumStatus.CHECKIN.ToString();
                maintenanceHistoryStatus.MaintenanceInformationId = main.InformationMaintenanceId;
                await _unitOfWork.MaintenanceHistoryStatuses.Add(maintenanceHistoryStatus);

                await _unitOfWork.InformationMaintenance.Update(main);
                await _unitOfWork.Commit();
                return _mapper.Map<ResponseMaintenanceInformation>(main);
            }
            else
            {
                throw new Exception("Không thể cập nhật thông tin bảo dưỡng booking này");
            }




        }

        public async Task<List<ResponseMaintenanceInformation>> GetListByPlanAndVehicleAndCenterAndStatusWatingbycar(Guid planId, Guid vehicleId, Guid centerId)
        {
            return _mapper.Map<List<ResponseMaintenanceInformation>>(
                await _unitOfWork.InformationMaintenance.GetListByPlanAndVehicleAndCenterAndStatusWatingbycar(planId, vehicleId, centerId));
        }

        //public async Task<ResponseMaintenanceInformation> CreateHavePackage(CreateMaintenanceInformationHavePackage create)
        //{
        //    var mi = _mapper.Map<MaintenanceInformation>(create);
        //    mi.CreatedDate = DateTime.Now;
        //    mi.Status = EnumStatus.CHECKIN.ToString();
        //    mi.TotalPrice = 0;
        //    var booking = await _unitOfWork.Booking.GetById(mi.BookingId);
        //    mi.Note = booking.Note;
        //    await _unitOfWork.CustomerCare.GetById(mi.CustomerCareId);
        //    await _unitOfWork.Booking.GetById(mi.BookingId);
        //    var listmainbybooking = await _unitOfWork.InformationMaintenance.GetListByBookingId(booking.BookingId);
        //    await _unitOfWork.InformationMaintenance.Add(mi);
        //    if (!listmainbybooking.All(c => c.Status.Equals(STATUSENUM.STATUSBOOKING.CANCELLED.ToString())))
        //    {
        //        throw new Exception("Booking này không thể add thêm maininfor được");
        //    }

        //    var schedule = await _unitOfWork.MaintenanceSchedule.GetByID(mi.MaintananceScheduleId);
        //    var vehicle = await _unitOfWork.Vehicles.GetById(booking.VehicleId);


        //    if (schedule.VehicleModelId != vehicle.VehicleModelId)
        //    {
        //        throw new Exception("Trung tâm này không hỗ trợ gói dịch vụ cho xe " + schedule.VehicleModel.VehicleModelName);
        //    }
        //    var list = await _unitOfWork.MaintenanceService.GetListPackageByOdoAndCenterIdAndVehicleId(booking.MaintenanceCenterId, mi.MaintananceScheduleId, vehicle.VehicleModelId);
        //    if (!list.Any())
        //    {
        //        throw new Exception("Trung tâm này không hỗ trợ gói dịch vụ cho xe ");
        //    }
        //    foreach (var item in list)
        //    {
        //        var cost = await _unitOfWork.MaintenanceServiceCost.GetByIdMaintenanceServiceActiveAndServiceAdmin
        //              (EnumStatus.ACTIVE.ToString(), EnumStatus.ACTIVE.ToString(), EnumStatus.ACTIVE.ToString(), item.MaintenanceServiceId);
        //        MaintenanceServiceInfo maintenanceServiceInfo = new MaintenanceServiceInfo
        //        {
        //            InformationMaintenanceId = mi.InformationMaintenanceId,
        //            ActualCost = cost.ActuralCost,
        //            Discount = 0,
        //            CreatedDate = DateTime.Now,
        //            Note = create.InformationMaintenanceName,
        //            Quantity = 1,
        //            Status = EnumStatus.ACTIVE.ToString(),
        //            TotalCost = (cost.ActuralCost * 1) * (1 - (0) / 100f),
        //            MaintenanceServiceCostId = cost.MaintenanceServiceCostId,
        //            MaintenanceServiceInfoId = Guid.NewGuid(),
        //            MaintenanceServiceInfoName = cost.MaintenanceService.MaintenanceServiceName,
        //        };
        //        //await _unitOfWork.MaintenanceServiceCost.CheckCostVehicleIdAndIdCost(check.Vehicles.VehicleModelId, msi.MaintenanceServiceCostId);
        //        mi.TotalPrice += maintenanceServiceInfo.TotalCost;
        //        await _unitOfWork.MaintenanceServiceInfo.Add(maintenanceServiceInfo);
        //    }
        //    await _unitOfWork.Commit();
        //    return _mapper.Map<ResponseMaintenanceInformation>(mi);

        //}



        //public Task<List<ResponseMaintenanceInformation>> GetListByCenterAndStatusCheckin(Guid id)
        //{
        //    return _mapper.Map<List<ResponseMaintenanceInformation>>(
        //                   await _unitOfWork.InformationMaintenance.GetListByCenter(account.MaintenanceCenter.MaintenanceCenterId));
        //}
    }
}
