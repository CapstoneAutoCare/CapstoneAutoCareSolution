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

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingsService;

        public BookingsController(IBookingService bookingsService)
        {
            _bookingsService = bookingsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseBooking>>> GetAll()
        {
            return Ok(await _bookingsService.GetAll());

        }

        [HttpGet]
        public async Task<ActionResult<ResponseBooking>> GetById(Guid id)
        {
            return Ok(await _bookingsService.GetById(id));
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<ResponseBooking>>> GetListByClient()
        {
            return Ok(await _bookingsService.GetListByClient());
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<ResponseBooking>>> GetListByCenter()
        {
            return Ok(await _bookingsService.GetListByCenter());
        }
       
        [HttpGet]
        public async Task<ActionResult<List<ResponseBooking>>> GetListByCenterAndClient(Guid centerId, Guid clientId)
        {
            return Ok(await _bookingsService.GetListByCenterAndClient(centerId, clientId));
        }
        //[HttpPut]
        //public async Task<IActionResult> PutBooking(Guid id, Booking booking)
        //{

        //    return NoContent();
        //}

        [HttpPost]
        public async Task<ActionResult<ResponseBooking>> Post([FromBody] RequestBooking booking)
        {
            return Ok(await _bookingsService.Create(booking));

        }
        [HttpPost]
        public async Task<ActionResult<ResponseBooking>> PostHaveItems([FromBody] RequestBookingHaveItems booking)
        {
            return Ok(await _bookingsService.CreateHaveItemsByClient(booking));

        }
        [HttpPatch]
        public async Task<ActionResult<ResponseBooking>> UpdateStatus(Guid bookingId, string status)
        {
            return Ok(await _bookingsService.UpdateStatus(bookingId, status));

        }
        //[HttpDelete]
        //public async Task<IActionResult> DeleteBooking(Guid id)
        //{
        //    return NoContent();
        //}


    }
}
