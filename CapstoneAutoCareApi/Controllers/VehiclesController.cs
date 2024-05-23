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
    public class VehiclesController : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicles>>> GetVehicles()
        {
            return NotFound();

        }

        [HttpGet]
        public async Task<ActionResult<Vehicles>> GetVehicles(Guid id)
        {

            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> PutVehicles(Guid id, Vehicles vehicles)
        {

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Vehicles>> Post(Vehicles vehicles)
        {
            return NoContent();

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteVehicles(Guid id)
        {

            return NoContent();
        }


    }
}
