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
using CapstoneAutoCareApi.Hubs;
using Microsoft.AspNetCore.SignalR;

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
        [Authorize]
        public async Task<ActionResult<List<ResponseBooking>>> GetListByCenter()
        {
            return Ok(await _bookingService.GetListByCenter());
        }
        [HttpGet]
        [Authorize]
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
        //[HttpPut]
        //public async Task<IActionResult> PutBooking(Guid id, Booking booking)
        //{

        //    return NoContent();
        //}

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
        [HttpPost]
        public async Task<ActionResult<ResponseBooking>> PostHavePackage([FromBody] CreateBookingPackage booking)
        {
            return Ok(await _bookingService.CreatePackageByClient(booking));

        }

        [HttpPatch]
        [Authorize(Roles = "CUSTOMERCARE,CUSTOMER")]
        public async Task<ActionResult<ResponseBooking>> UpdateStatus(Guid bookingId, string status)
        {
            return Ok(await _bookingService.UpdateStatus(bookingId, status));

        }
        //[HttpDelete]
        //public async Task<IActionResult> DeleteBooking(Guid id)
        //{
        //    return NoContent();
        //}


    }
}
