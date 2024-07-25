using AutoMapper;
using Domain.Entities;
using Domain.Enum;
using Infrastructure.Common.Request.RequestBooking;
using Infrastructure.Common.Response.ResponseBooking;
using Infrastructure.Common.Response.ResponseCustomerCare;
using Infrastructure.ISecurity;
using Infrastructure.IUnitofWork;
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

        public BookingServiceImp(IUnitOfWork unitOfWork, IMapper mapper, ITokensHandler tokensHandler, IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokensHandler = tokensHandler;
            _emailService = emailService;
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

            var mi = _mapper.Map<MaintenanceInformation>(check.MaintenanceInformation);
            await _unitOfWork.CustomerCare.GetById(mi.CustomerCareId);
            mi.BookingId = booking.BookingId;
            mi.CreatedDate = DateTime.Now;
            mi.InformationMaintenanceName = "Client created Booking and Maintenance Infor";
            mi.Note = check.Note;
            mi.Status =EnumStatus.CREATEDBYClIENT.ToString();
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
                    sp.Discount = 10;
                    sp.TotalCost = (sp.ActualCost * sp.Quantity) * (1 - (sp.Discount) / 100f);
                    sp.InformationMaintenanceId = mi.InformationMaintenanceId;
                    mi.TotalPrice += sp.TotalCost;
                    await _unitOfWork.SparePartsItemCost.GetById(sp.SparePartsItemCostId);
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
                    msi.Discount = 10;
                    msi.TotalCost = (msi.ActualCost * msi.Quantity) * (1 - (msi.Discount) / 100f);
                    msi.InformationMaintenanceId = mi.InformationMaintenanceId;
                    mi.TotalPrice += msi.TotalCost;

                    await _unitOfWork.MaintenanceServiceCost.GetById(msi.MaintenanceServiceCostId);
                    await _unitOfWork.MaintenanceServiceInfo.Add(msi);
                }
            }

            await _unitOfWork.Commit();
            return _mapper.Map<ResponseBooking>(check);


        }

        public async Task<List<ResponseBooking>> GetAll()
        {
            return _mapper.Map<List<ResponseBooking>>(await _unitOfWork.Booking.GetAll());
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


        public async Task<List<ResponseBooking>> GetListByClient()
        {
            var email = _tokensHandler.ClaimsFromToken();
            var account = await _unitOfWork.Account.Profile(email);
            return _mapper.Map<List<ResponseBooking>>(await _unitOfWork.Booking.GetListByClient(account.Client.ClientId));

        }

        public async Task<ResponseBooking> UpdateStatus(Guid bookingId, string status)
        {
            var booking = await _unitOfWork.Booking.GetById(bookingId);
            booking.Status = status.ToString();
            await _unitOfWork.Booking.Update(booking);
            var account = await _unitOfWork.Account.GetByClientId(booking.ClientId);
            var checkInfor = await _unitOfWork.InformationMaintenance.GetByBookingId(booking.BookingId);
            if (checkInfor != null)
            {
                if (booking.Status.Equals(STATUSENUM.STATUSBOOKING.ACCEPTED.ToString()))
                {
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
                }
                
            }

            await _unitOfWork.Commit();
            return _mapper.Map<ResponseBooking>(booking);
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
            await _unitOfWork.Vehicles.GetById(booking.VehicleId);
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
    }
}
