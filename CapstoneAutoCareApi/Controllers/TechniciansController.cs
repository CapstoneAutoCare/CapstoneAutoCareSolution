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
using Infrastructure.Common.Response.ResponseTechnicanMain;
using Infrastructure.Common.Request.RequestMaintenanceTechinican;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TechniciansController : ControllerBase
    {

        private readonly IMaintenanceTechinicanService _maintenanceTechinicanService;

        public TechniciansController(IMaintenanceTechinicanService maintenanceTechinicanService)
        {
            _maintenanceTechinicanService = maintenanceTechinicanService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseMaintenanceTechinican>>> GetAll()
        {
            return Ok(await _maintenanceTechinicanService.GetAll());
        }

        [HttpGet]
        public async Task<ActionResult<ResponseMaintenanceTechinican>> GetById(Guid id)
        {
            return Ok(await _maintenanceTechinicanService.GetById(id));
        }

        //[HttpPut]
        //public async Task<IActionResult> PutTechnician(Guid id, Technician technician)
        //{

        //    return NoContent();
        //}
        [HttpPost]
        public async Task<ActionResult<ResponseMaintenanceTechinican>> Post(CreateMaintenanceTechinican technician)
        {
            return Ok(await _maintenanceTechinicanService.Create(technician));

        }

        //[HttpDelete]
        //public async Task<IActionResult> Delete(Guid id)
        //{

        //    return NoContent();
        //}


    }
}
