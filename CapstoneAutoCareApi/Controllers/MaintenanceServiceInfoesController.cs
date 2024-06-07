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
using Infrastructure.Common.Request.RequestMaintenanceServiceInfo;
using Infrastructure.Common.Response.ResponseMaintenanceService;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MaintenanceServiceInfoesController : ControllerBase
    {
        private readonly IMaintenanceServiceInfoService _maintenanceServiceInfoService;

        public MaintenanceServiceInfoesController(IMaintenanceServiceInfoService maintenanceServiceInfoService)
        {
            _maintenanceServiceInfoService = maintenanceServiceInfoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseMaintenanceServiceInfo>>> GetAll()
        {
            return Ok(await _maintenanceServiceInfoService.GetAll());
        }

        [HttpGet]
        public async Task<ActionResult<ResponseMaintenanceServiceInfo>> GetById(Guid id)
        {
            return Ok(await _maintenanceServiceInfoService.GetById(id));
        }

        //[HttpPut]
        //public async Task<IActionResult> PutMaintenanceServiceInfo(Guid id, MaintenanceServiceInfo maintenanceServiceInfo)
        //{
        //}

        [HttpPost]
        public async Task<ActionResult<ResponseMaintenanceServiceInfo>> Post(CreateMaintenanceServiceInfo maintenanceServiceInfo)
        {
            return Ok(await _maintenanceServiceInfoService.Create(maintenanceServiceInfo));

        }

    }
}
