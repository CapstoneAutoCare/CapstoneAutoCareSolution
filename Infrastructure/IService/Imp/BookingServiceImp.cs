using Application.Dashboard;
using AutoMapper;
using Domain.Entities;
using Domain.Enum;
using Infrastructure.Common.Request.RequestBooking;
using Infrastructure.Common.Response.ResponseBooking;
using Infrastructure.Common.Response.ResponseCustomerCare;
using Infrastructure.ISecurity;
using Infrastructure.IUnitofWork;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IService.Imp
{
    public class BookingServiceImp : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokensHandler _tokensHandler;
        private readonly IEmailService _emailService;
        private readonly IHubContext<NotificationHub> _hubContext;

        public BookingServiceImp(IUnitOfWork unitOfWork, IMapper mapper, ITokensHandler tokensHandler, IEmailService emailService, IHubContext<NotificationHub> hubContext)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokensHandler = tokensHandler;
            _emailService = emailService;
            _hubContext = hubContext;
        }

        public async Task<ResponseBooking> Create(RequestBooking create)
        {

            var booking = _mapper.Map<Booking>(create);
            var email = _tokensHandler.ClaimsFromToken();
            var account = await _unitOfWork.Account.Profile(email);
            var client = await _unitOfWork.Client.GetById(account.Client.ClientId);
            booking.ClientId = client.ClientId;
            await _unitOfWork.Vehicles.GetById(booking.VehicleId);

            if (booking.MaintananceScheduleId == null)
            {
                await _unitOfWork.MaintenanceCenter.GetById(booking.MaintenanceCenterId);
                booking.Status = "WAITING";
                booking.CreatedDate = DateTime.Now;
                await _unitOfWork.Booking.Add(booking);
                await _unitOfWork.Commit();
                return _mapper.Map<ResponseBooking>(booking);
            }
            else
            {
                await _unitOfWork.MaintenanceSchedule.GetByID(booking.MaintananceScheduleId);
                booking.Status = "WAITING";
                booking.CreatedDate = DateTime.Now;
                await _unitOfWork.Booking.Add(booking);

                await _unitOfWork.Commit();
                return _mapper.Map<ResponseBooking>(booking);
            }

        }

        public async Task<ResponseBooking> CreateHaveItemsByClient(RequestBookingHaveItems create)
        {
            var booking = _mapper.Map<Booking>(create);
            var email = _tokensHandler.ClaimsFromToken();
            var account = await _unitOfWork.Account.Profile(email);
            var client = await _unitOfWork.Client.GetById(account.Client.ClientId);
            booking.ClientId = client.ClientId;
            var check = await IsBookingHaveSchedule(booking);
            await _unitOfWork.Booking.Add(check);
            var center = await _unitOfWork.MaintenanceCenter.GetById(booking.MaintenanceCenterId);
            if (center.Account.Status == EnumStatus.INACTIVE.ToString())
            {
                throw new Exception("Trung tâm không hoạt động");
            }
            var mi = _mapper.Map<MaintenanceInformation>(check.MaintenanceInformation);
            //await _unitOfWork.CustomerCare.GetById(mi.CustomerCareId);
            mi.BookingId = booking.BookingId;
            mi.CreatedDate = DateTime.Now;
            mi.InformationMaintenanceName = "Khách Hàng Tạo Lịch Đặt";
            mi.Note = check.Note;
            mi.Status = EnumStatus.CREATEDBYClIENT.ToString();
            await _unitOfWork.InformationMaintenance.Add(mi);
            MaintenanceHistoryStatus historyStatus = new MaintenanceHistoryStatus
            {
                MaintenanceHistoryStatusId = new Guid(),
                Status = EnumStatus.CREATEDBYClIENT.ToString(),
                DateTime = DateTime.Now,
                MaintenanceInformationId = mi.InformationMaintenanceId,
                Note = mi.Note,
            };
            await _unitOfWork.MaintenanceHistoryStatuses.Add(historyStatus);

            if (mi.MaintenanceSparePartInfos.Count() == 0 && mi.MaintenanceServiceInfos.Count() == 0)
            {
                throw new Exception("Booking items should have items");
            }

            if (mi.MaintenanceSparePartInfos.Count() > 0)
            {
                foreach (var i in mi.MaintenanceSparePartInfos)
                {
                    var sp = _mapper.Map<MaintenanceSparePartInfo>(i);
                    if (sp.SparePartsItemCostId == null)
                    {
                        throw new Exception("Require add Product in Center Cost");
                    }
                    sp.Status = EnumStatus.ACTIVE.ToString();
                    sp.CreatedDate = DateTime.Now;
                    sp.Discount = 0;
                    sp.TotalCost = (sp.ActualCost * sp.Quantity) * (1 - (sp.Discount) / 100f);
                    sp.InformationMaintenanceId = mi.InformationMaintenanceId;
                    mi.TotalPrice += sp.TotalCost;
                    //await _unitOfWork.SparePartsItemCost.GetById(sp.SparePartsItemCostId);

                    await _unitOfWork.SparePartsItemCost.CheckCostVehicleIdAndIdCost(check.Vehicles.VehicleModelId, sp.SparePartsItemCostId);
                    await _unitOfWork.MaintenanceSparePartInfo.Add(sp);
                }
            }
            if (mi.MaintenanceServiceInfos.Count() > 0)
            {
                foreach (var i in mi.MaintenanceServiceInfos)
                {
                    var msi = _mapper.Map<MaintenanceServiceInfo>(i);
                    if (msi.MaintenanceServiceCostId == null)
                    {
                        throw new Exception("Require add Product in Center Cost");
                    }
                    msi.Status = EnumStatus.ACTIVE.ToString();
                    msi.CreatedDate = DateTime.Now;
                    msi.Discount = 0;
                    msi.TotalCost = (msi.ActualCost * msi.Quantity) * (1 - (msi.Discount) / 100f);
                    msi.InformationMaintenanceId = mi.InformationMaintenanceId;
                    mi.TotalPrice += msi.TotalCost;

                    //await _unitOfWork.MaintenanceServiceCost.GetById(msi.MaintenanceServiceCostId);
                    await _unitOfWork.MaintenanceServiceCost.CheckCostVehicleIdAndIdCost(check.Vehicles.VehicleModelId, msi.MaintenanceServiceCostId);

                    await _unitOfWork.MaintenanceServiceInfo.Add(msi);
                }
            }

            await _unitOfWork.Commit();
            return _mapper.Map<ResponseBooking>(check);


        }

        public async Task<ResponseBooking> CreatePackageByClient(CreateBookingPackage create)
        {
            var booking = _mapper.Map<Booking>(create);
            var email = _tokensHandler.ClaimsFromToken();
            var account = await _unitOfWork.Account.Profile(email);
            var client = await _unitOfWork.Client.GetById(account.Client.ClientId);
            booking.ClientId = client.ClientId;
            var vehicle = await _unitOfWork.Vehicles.GetById(booking.VehicleId);
            booking.Status = "WAITING";
            booking.CreatedDate = DateTime.Now;

            var center = await _unitOfWork.MaintenanceCenter.GetById(booking.MaintenanceCenterId);
            if (center.Account.Status == EnumStatus.INACTIVE.ToString())
            {
                throw new Exception("Trung tâm không hoạt động");
            }
            await _unitOfWork.Booking.Add(booking);
            MaintenanceInformation maintenanceInformation = new MaintenanceInformation
            {
                BookingId = booking.BookingId,
                CreatedDate = DateTime.Now,
                CustomerCareId = null,
                FinishedDate = null,
                InformationMaintenanceId = Guid.NewGuid(),
                InformationMaintenanceName = create.InformationName,
                Note = create.Note,
                Status = EnumStatus.CREATEDBYClIENT.ToString(),
                TotalPrice = 0,
            };
            await _unitOfWork.InformationMaintenance.Add(maintenanceInformation);
            MaintenanceHistoryStatus historyStatus = new MaintenanceHistoryStatus
            {
                MaintenanceHistoryStatusId = new Guid(),
                Status = EnumStatus.CREATEDBYClIENT.ToString(),
                DateTime = DateTime.Now,
                MaintenanceInformationId = maintenanceInformation.InformationMaintenanceId,
                Note = maintenanceInformation.Note,
            };
            await _unitOfWork.MaintenanceHistoryStatuses.Add(historyStatus);
            var schedule = await _unitOfWork.MaintenanceSchedule.GetByID(booking.MaintananceScheduleId);
            if (schedule.VehicleModelId != vehicle.VehicleModelId)
            {
                throw new Exception("Trung tâm này không hỗ trợ gói dịch vụ cho xe " + schedule.VehicleModel.VehicleModelName);
            }
            var list = await _unitOfWork.MaintenanceService.GetListPackageByOdoAndCenterIdAndVehicleId(booking.MaintenanceCenterId, booking.MaintananceScheduleId, vehicle.VehicleModelId);
            if (!list.Any())
            {
                throw new Exception("Trung tâm này không hỗ trợ gói dịch vụ cho xe ");
            }
            foreach (var item in list)
            {
                var cost = await _unitOfWork.MaintenanceServiceCost.GetByIdMaintenanceServiceActiveAndServiceAdmin
                      (EnumStatus.ACTIVE.ToString(), EnumStatus.ACTIVE.ToString(), EnumStatus.ACTIVE.ToString(), item.MaintenanceServiceId);
                MaintenanceServiceInfo maintenanceServiceInfo = new MaintenanceServiceInfo
                {
                    InformationMaintenanceId = maintenanceInformation.InformationMaintenanceId,
                    ActualCost = cost.ActuralCost,
                    Discount = 0,
                    CreatedDate = DateTime.Now,
                    Note = create.InformationName,
                    Quantity = 1,
                    Status = EnumStatus.ACTIVE.ToString(),
                    TotalCost = (cost.ActuralCost * 1) * (1 - (0) / 100f),
                    MaintenanceServiceCostId = cost.MaintenanceServiceCostId,
                    MaintenanceServiceInfoId = Guid.NewGuid(),
                    MaintenanceServiceInfoName = cost.MaintenanceService.MaintenanceServiceName,
                };
                //await _unitOfWork.MaintenanceServiceCost.CheckCostVehicleIdAndIdCost(check.Vehicles.VehicleModelId, msi.MaintenanceServiceCostId);
                maintenanceInformation.TotalPrice += maintenanceServiceInfo.TotalCost;
                await _unitOfWork.MaintenanceServiceInfo.Add(maintenanceServiceInfo);
            }
            await _unitOfWork.Commit();

            return _mapper.Map<ResponseBooking>(booking);

        }

        public async Task<List<ResponseBooking>> GetAll()
        {
            return _mapper.Map<List<ResponseBooking>>(await _unitOfWork.Booking.GetAll());
        }

        public async Task<List<MonthlyBookingSummary>> GetBookingsByMonthByCenterId(Guid id)
        {
            return _mapper.Map<List<MonthlyBookingSummary>>(await _unitOfWork.Booking.GetBookingsByMonthByCenterId(id));
        }

        public async Task<List<MonthlyBookingSummary>> GetBookingsByMonthInYearByCenterId(Guid id, int year)
        {
            return _mapper.Map<List<MonthlyBookingSummary>>(await _unitOfWork.Booking.GetBookingsByMonthInYearByCenterId(id, year));
        }

        public async Task<ResponseBooking> GetById(Guid id)
        {
            return _mapper.Map<ResponseBooking>(await _unitOfWork.Booking.GetById(id));
        }

        public async Task<List<ResponseBooking>> GetListByCenter()
        {
            var email = _tokensHandler.ClaimsFromToken();
            var account = await _unitOfWork.Account.Profile(email);
            return _mapper.Map<List<ResponseBooking>>(await _unitOfWork.Booking.GetListByCenter(account.MaintenanceCenter.MaintenanceCenterId));
        }


        public async Task<List<ResponseBooking>> GetListByCenterAndClient(Guid centerid, Guid clientId)
        {
            return _mapper.Map<List<ResponseBooking>>(await _unitOfWork.Booking.GetListByCenterAndClient(centerid, clientId));
        }

        public async Task<List<ResponseBooking>> GetListByCenterId(Guid id)
        {
            var booking = await _unitOfWork.Booking.GetListByCenter(id);
            var list = _mapper.Map<List<ResponseBooking>>(booking);
            await _hubContext.Clients.Group(id.ToString()).SendAsync("ReceiveBookingUpdate", list);

            return list;
        }


        public async Task<List<ResponseBooking>> GetListByClient()
        {
            var email = _tokensHandler.ClaimsFromToken();
            var account = await _unitOfWork.Account.Profile(email);
            return _mapper.Map<List<ResponseBooking>>(await _unitOfWork.Booking.GetListByClient(account.Client.ClientId));

        }

        public async Task<ResponseBooking> UpdateStatus(Guid bookingId, string status)
        {
            var booking = await _unitOfWork.Booking.GetById(bookingId);

            var checkInfor = await _unitOfWork.InformationMaintenance.GetByBookingId(booking.BookingId);
            if (booking.Status.Equals("WAITING") && status.Equals(STATUSENUM.STATUSBOOKING.ACCEPTED.ToString()))
            {
                var email = _tokensHandler.ClaimsFromToken();
                var account = await _unitOfWork.Account.Profile(email);
                checkInfor.CustomerCareId = account.CustomerCare.CustomerCareId;

                booking.Status = status;
                await _unitOfWork.Booking.Update(booking);
                MaintenanceHistoryStatus maintenanceHistoryStatus = new MaintenanceHistoryStatus();
                maintenanceHistoryStatus.Status = EnumStatus.WAITINGBYCAR.ToString();
                maintenanceHistoryStatus.DateTime = DateTime.Now;
                maintenanceHistoryStatus.Note = EnumStatus.WAITINGBYCAR.ToString();
                maintenanceHistoryStatus.MaintenanceInformationId = checkInfor.InformationMaintenanceId;
                var checkStatus = await _unitOfWork.MaintenanceHistoryStatuses
                      .CheckExistNameByNameAndIdInfor(maintenanceHistoryStatus.MaintenanceInformationId, maintenanceHistoryStatus.Status);
                if (checkStatus == null)
                {
                    await _unitOfWork.MaintenanceHistoryStatuses.Add(maintenanceHistoryStatus);

                }
                checkInfor.Status = EnumStatus.WAITINGBYCAR.ToString();
                await _unitOfWork.InformationMaintenance.Update(checkInfor);
                await _emailService.SendMail("duypdxse161418@fpt.edu.vn", maintenanceHistoryStatus.Status, "Booking");
                await _unitOfWork.Commit();
                return _mapper.Map<ResponseBooking>(booking);
            }
            else if (booking.Status.Equals("WAITING") && status.Equals(STATUSENUM.STATUSBOOKING.CANCELLED.ToString()))
            {
                booking.Status = status;
                await _unitOfWork.Booking.Update(booking);
                MaintenanceHistoryStatus maintenanceHistoryStatus = new MaintenanceHistoryStatus();
                maintenanceHistoryStatus.Status = STATUSENUM.STATUSBOOKING.CANCELLED.ToString();
                maintenanceHistoryStatus.DateTime = DateTime.Now;
                maintenanceHistoryStatus.Note = STATUSENUM.STATUSBOOKING.CANCELLED.ToString();
                maintenanceHistoryStatus.MaintenanceInformationId = checkInfor.InformationMaintenanceId;
                var checkStatus = await _unitOfWork.MaintenanceHistoryStatuses
                      .CheckExistNameByNameAndIdInfor(maintenanceHistoryStatus.MaintenanceInformationId, maintenanceHistoryStatus.Status);
                if (checkStatus == null)
                {
                    await _unitOfWork.MaintenanceHistoryStatuses.Add(maintenanceHistoryStatus);

                }
                checkInfor.Status = STATUSENUM.STATUSBOOKING.CANCELLED.ToString();
                await _unitOfWork.InformationMaintenance.Update(checkInfor);
                await _emailService.SendMail("duypdxse161418@fpt.edu.vn", maintenanceHistoryStatus.Status, "Booking");
                await _unitOfWork.Commit();
                return _mapper.Map<ResponseBooking>(booking);
            }
            else
            {
                throw new Exception("Booking Status existed Status: " + booking.Status + " Can't Change Status  :" + status);
            }


        }

        public async Task<ResponseBooking> UpdateStatusBackup(Guid bookingId, string status)
        {
            var booking = await _unitOfWork.Booking.GetById(bookingId);
            booking.Status = status.ToString();
            await _unitOfWork.Booking.Update(booking);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseBooking>(booking);
        }

        private async Task<Booking> IsBookingHaveSchedule(Booking booking)
        {
            var vehicle = await _unitOfWork.Vehicles.GetById(booking.VehicleId);
            booking.Status = "WAITING";
            booking.CreatedDate = DateTime.Now;
            if (booking.MaintananceScheduleId == null)
            {
                await _unitOfWork.MaintenanceCenter.GetById(booking.MaintenanceCenterId);
            }
            else
            {
                await _unitOfWork.MaintenanceSchedule.GetByID(booking.MaintananceScheduleId);
                await _unitOfWork.MaintenanceCenter.GetById(booking.MaintenanceCenterId);
            }
            return booking;
        }
        public class PaymentExecuteRequest
        {
            public string Uri { get; set; }
        }
    }
}
