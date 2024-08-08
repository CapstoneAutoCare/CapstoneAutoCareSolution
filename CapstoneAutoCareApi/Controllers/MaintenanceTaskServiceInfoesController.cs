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

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MaintenanceTaskServiceInfoesController : ControllerBase
    {
        private readonly IMaintenanceTaskServiceInfoService _maintenanceTaskServiceInfoService;

        public MaintenanceTaskServiceInfoesController(IMaintenanceTaskServiceInfoService maintenanceTaskServiceInfoService)
        {
            _maintenanceTaskServiceInfoService = maintenanceTaskServiceInfoService;
        }


        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<MaintenanceTaskServiceInfo>>> GetAll()
        //{
        //    return NotFound();

        //}

        //[HttpGet]
        //public async Task<ActionResult<MaintenanceTaskServiceInfo>> GetById(Guid id)
        //{
        //    return NotFound();
        //}

        [HttpPatch]
        public async Task<ActionResult<ResponseMainTaskService>> PatchStatus(Guid id, string status)
        {
            return Ok(await _maintenanceTaskServiceInfoService.ChangeStatus(id, status));
        }

        //[HttpPost]
        //public async Task<ActionResult<MaintenanceTaskServiceInfo>> Post(MaintenanceTaskServiceInfo maintenanceTaskServiceInfo)
        //{
        //    return NoContent();

        //}

        //[HttpDelete]
        //public async Task<IActionResult> Remove(Guid id)
        //{
        //    return NoContent();
        //}

    }
}
