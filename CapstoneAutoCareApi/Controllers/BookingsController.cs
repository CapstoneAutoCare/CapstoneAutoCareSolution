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
        public async Task<ActionResult<IEnumerable<ResponseBooking>>> GetBookings()
        {
            return Ok(await _bookingsService.GetAll());

        }

        [HttpGet]
        public async Task<ActionResult<ResponseBooking>> GetBooking(Guid id)
        {
            return Ok(await _bookingsService.GetById(id));

        }
        //[HttpPut]
        //public async Task<IActionResult> PutBooking(Guid id, Booking booking)
        //{

        //    return NoContent();
        //}

        [HttpPost]
        public async Task<ActionResult<ResponseBooking>> PostBooking([FromBody] RequestBooking booking)
        {
            return Ok(await _bookingsService.Create(booking));

        }
        [HttpPost]
        public async Task<ActionResult<ResponseBooking>> PostBookingHaveItems([FromBody] RequestBookingHaveItems booking)
        {
            return Ok(await _bookingsService.CreateHaveItemsByClient(booking));

        }
        //[HttpDelete]
        //public async Task<IActionResult> DeleteBooking(Guid id)
        //{
        //    return NoContent();
        //}


    }
}
