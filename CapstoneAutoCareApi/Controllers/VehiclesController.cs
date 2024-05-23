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
using Infrastructure.Common.Response.ResponseVehicles;
using Infrastructure.Common.Request.RequestVehicles;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {

        private readonly IVehiclesService _vehiclesService;

        public VehiclesController(IVehiclesService vehiclesService)
        {
            _vehiclesService = vehiclesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseVehicles>>> GetAll()
        {
            return Ok(await _vehiclesService.GetAll());

        }

        [HttpGet]
        public async Task<ActionResult<ResponseVehicles>> GetById(Guid id)
        {

            return Ok(await _vehiclesService.GetById(id));
        }

        //[HttpPut]
        //public async Task<IActionResult> PutVehicles(Guid id, Vehicles vehicles)
        //{

        //    return NoContent();
        //}

        [HttpPost]
        public async Task<ActionResult<ResponseVehicles>> Post(CreateVehicle vehicles)
        {
            return Ok(await _vehiclesService.Create(vehicles));
        }

        //[HttpDelete]
        //public async Task<IActionResult> DeleteVehicles(Guid id)
        //{

        //    return NoContent();
        //}


    }
}
