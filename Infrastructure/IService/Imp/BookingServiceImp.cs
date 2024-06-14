using AutoMapper;
using Domain.Entities;
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

        public BookingServiceImp(IUnitOfWork unitOfWork, IMapper mapper, ITokensHandler tokensHandler)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokensHandler = tokensHandler;
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
            await _unitOfWork.InformationMaintenance.Add(mi);
            MaintenanceHistoryStatus historyStatus = new MaintenanceHistoryStatus
            {
                MaintenanceHistoryStatusId = new Guid(),
                Status = "CREATED BY ClIENT",
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
                    if (sp.SparePartsItemId == null)
                    {
                        throw new Exception("Require add Product in Center");
                    }
                    sp.Status = "INACTIVE";
                    sp.CreatedDate = DateTime.Now;
                    sp.Discount = 10;
                    sp.TotalCost = (sp.ActualCost * sp.Quantity) * (1 - (sp.Discount) / 100);
                    sp.InformationMaintenanceId = mi.InformationMaintenanceId;
                    await _unitOfWork.SparePartsItem.GetById(sp.SparePartsItemId);
                    await _unitOfWork.MaintenanceSparePartInfo.Add(sp);
                }
            }
            if (mi.MaintenanceServiceInfos.Count() > 0)
            {
                foreach (var i in mi.MaintenanceServiceInfos)
                {
                    var msi = _mapper.Map<MaintenanceServiceInfo>(i);
                    if (msi.MaintenanceServiceId == null)
                    {
                        throw new Exception("Require add Product in Center");
                    }
                    msi.Status = "INACTIVE";
                    msi.CreatedDate = DateTime.Now;
                    msi.Discount = 10;
                    msi.TotalCost = (msi.ActualCost * msi.Quantity) * (1 - (msi.Discount) / 100);
                    msi.InformationMaintenanceId = mi.InformationMaintenanceId;
                    await _unitOfWork.MaintenanceService.GetById(msi.MaintenanceServiceId);
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

        public async Task<List<ResponseBooking>> GetListByClient()
        {
            var email = _tokensHandler.ClaimsFromToken();
            var account = await _unitOfWork.Account.Profile(email);
            return _mapper.Map<List<ResponseBooking>>(await _unitOfWork.Booking.GetListByClient(account.Client.ClientId));

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
