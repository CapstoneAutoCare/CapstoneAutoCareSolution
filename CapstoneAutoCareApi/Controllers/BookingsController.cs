using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Application;
using Domain.Entities;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
            return NoContent();

        }

        [HttpGet]
        public async Task<ActionResult<Booking>> GetBooking(Guid id)
        {
            return NoContent();

        }
        [HttpPut]
        public async Task<IActionResult> PutBooking(Guid id, Booking booking)
        {

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking(Booking booking)
        {
            return NoContent();

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBooking(Guid id)
        {
            return NoContent();
        }


    }
}
