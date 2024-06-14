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
using Infrastructure.Common.Request.RequestAccount;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MaintenanceCentersController : ControllerBase
    {
        private readonly ICenterService _centerService;

        public MaintenanceCentersController(ICenterService centerService)
        {
            _centerService = centerService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaintenanceCenter>>> GetAll()
        {
            return Ok(await _centerService.GetAll());
        }

        [HttpGet]
        public async Task<ActionResult<MaintenanceCenter>> GetById(Guid id)
        {
            return Ok(await _centerService.GetById(id));
        }

        //[HttpPut]
        //public async Task<IActionResult> PutMaintenanceCenter(Guid id, MaintenanceCenter maintenanceCenter)
        //{
        //    return NoContent();
        //}

        [HttpPost]
        public async Task<ActionResult<MaintenanceCenter>> Post(CreateCenter create)
        {
            return Ok(await _centerService.Create(create));
        }

        //[HttpDelete]
        //public async Task<IActionResult> DeleteMaintenanceCenter(Guid id)
        //{
        //    return NoContent();
        //}


    }
}
