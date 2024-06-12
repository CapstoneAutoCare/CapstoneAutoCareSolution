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
using Infrastructure.Common.Request.RequestMaintenanceHistoryStatus;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MaintenanceHistoryStatusController : ControllerBase
    {
        private readonly IMaintenanceHistoryStatusService _maintenanceHistoryStatusService;

        public MaintenanceHistoryStatusController(IMaintenanceHistoryStatusService maintenanceHistoryStatusService)
        {
            _maintenanceHistoryStatusService = maintenanceHistoryStatusService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaintenanceHistoryStatus>>> GetAll()
        {
            return Ok(await _maintenanceHistoryStatusService.GetAll());
        }

        [HttpGet]
        public async Task<ActionResult<MaintenanceHistoryStatus>> GetById(Guid id)
        {
            return Ok(await _maintenanceHistoryStatusService.GetById(id));
        }

        //[HttpPut]
        //public async Task<IActionResult> Put(Guid id, MaintenanceHistoryStatus maintenanceHistoryStatus)
        //{
        //    return NoContent();
        //}

        [HttpPost]
        public async Task<ActionResult<MaintenanceHistoryStatus>> Post(CreateMaintenanceHistoryStatus maintenanceHistoryStatus)
        {
            return Ok(await _maintenanceHistoryStatusService.Create(maintenanceHistoryStatus));
        }

        //[HttpDelete]
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    return NoContent();
        //}
    }
}
