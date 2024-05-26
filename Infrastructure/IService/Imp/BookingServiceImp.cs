using AutoMapper;
using Domain.Entities;
using Infrastructure.Common.Request.RequestBooking;
using Infrastructure.Common.Response.ResponseBooking;
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

            if (booking.MaintananceScheduleId == null)
            {

                await _unitOfWork.Vehicles.GetById(booking.VehicleId);
                //await _unitOfWork.MaintenanceSchedule.GetByID(booking.MaintananceScheduleId);
                await _unitOfWork.MaintenanceCenter.GetById(booking.MaintenanceCenterId);
                booking.Status = "WAITING";
                booking.CreatedDate = DateTime.Now;

                await _unitOfWork.Booking.Add(booking);
                await _unitOfWork.Commit();
                return _mapper.Map<ResponseBooking>(booking);
            }
            else
            {
                await _unitOfWork.Vehicles.GetById(booking.VehicleId);
                await _unitOfWork.MaintenanceSchedule.GetByID(booking.MaintananceScheduleId);
                await _unitOfWork.MaintenanceCenter.GetById(booking.MaintenanceCenterId);

                booking.Status = "WAITING";
                booking.CreatedDate = DateTime.Now;

                await _unitOfWork.Booking.Add(booking);
                await _unitOfWork.Commit();
                return _mapper.Map<ResponseBooking>(booking);
            }

        }

        public async Task<List<ResponseBooking>> GetAll()
        {
            return _mapper.Map<List<ResponseBooking>>(await _unitOfWork.Booking.GetAll());
        }

        public async Task<ResponseBooking> GetById(Guid id)
        {
            return _mapper.Map<ResponseBooking>(await _unitOfWork.Booking.GetById(id));
        }
    }
}
