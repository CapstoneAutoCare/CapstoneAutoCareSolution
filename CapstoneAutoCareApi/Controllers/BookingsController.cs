using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Application;
using Domain.Entities;
using Infrastructure.IService;
using Infrastructure.Common.Request.RequestBooking;
using Infrastructure.Common.Response.ResponseBooking;
using Microsoft.AspNetCore.Authorization;
using Domain.Enum;
using Microsoft.AspNetCore.SignalR;
using Application.Dashboard;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseBooking>>> GetAll()
        {
            var bookings = await _bookingService.GetAll();


            return Ok(bookings);

        }

        [HttpGet]
        public async Task<ActionResult<ResponseBooking>> GetById(Guid id)
        {
            return Ok(await _bookingService.GetById(id));
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<ResponseBooking>>> GetListByClient()
        {
            return Ok(await _bookingService.GetListByClient());
        }

        [HttpGet]
        public async Task<ActionResult<List<MonthlyBookingSummary>>> GetBookingsByMonthByCenterId(Guid id)
        {
            return Ok(await _bookingService.GetBookingsByMonthByCenterId(id));
        }
        [HttpGet]
        public async Task<ActionResult<List<MonthlyBookingSummary>>> GetBookingsByMonthInYearByCenterId(Guid id,int year)
        {
            return Ok(await _bookingService.GetBookingsByMonthInYearByCenterId(id, year));
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<ResponseBooking>>> GetListByCenter()
        {
            return Ok(await _bookingService.GetListByCenter());
        }
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<List<ResponseBooking>>> GetListByCenterId(Guid id)
        {
            var bookings = await _bookingService.GetListByCenterId(id);

            return Ok(bookings);
        }

        [HttpGet]
        public async Task<ActionResult<List<ResponseBooking>>> GetListByCenterAndClient(Guid centerId, Guid clientId)
        {
            return Ok(await _bookingService.GetListByCenterAndClient(centerId, clientId));
        }
        [HttpGet]
        public async Task<ActionResult<List<ResponseBooking>>> GetListBookingCancelledInformationAndAcceptBooking(Guid centerId)
        {

            return Ok(await _bookingService.GetListBookingCancelledInformationAndAcceptBooking(centerId));
        }

        //[HttpPost]
        //public async Task<ActionResult<ResponseBooking>> Post([FromBody] RequestBooking booking)
        //{
        //    return Ok(await _bookingService.Create(booking));
        //}
        [HttpPost]
        public async Task<ActionResult<ResponseBooking>> PostHaveItems([FromBody] RequestBookingHaveItems booking)
        {
            return Ok(await _bookingService.CreateHaveItemsByClient(booking));

        }
        [Authorize]

        [HttpPost]
        public async Task<ActionResult<ResponseBooking>> PostMaintenanceBooking(CreateMaintenanceBooking booking)
        {
            return Ok(await _bookingService.CreateMaintenanceByClient(booking));

        }

        [HttpPatch]
        [Authorize]
        public async Task<ActionResult<ResponseBooking>> UpdateStatus(Guid? customercareId,Guid bookingId, string status)
        {
            return Ok(await _bookingService.UpdateStatus(customercareId,bookingId, status));

        }
        //[HttpDelete]
        //public async Task<IActionResult> DeleteBooking(Guid id)
        //{
        //    return NoContent();
        //}


    }
}
