using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Application;
using Domain.Entities;
using Infrastructure.Common.Response.MaintenancePlanResponse;
using Infrastructure.Common.Request.MaintenancePlan;
using Infrastructure.IService;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MaintenancePlansController : ControllerBase
    {
        private readonly IMaintenancePlanService _maintenancePlanService;

        public MaintenancePlansController(IMaintenancePlanService maintenancePlanService)
        {
            _maintenancePlanService = maintenancePlanService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseMaintenancePlan>>> GetAll()
        {
            return Ok(await _maintenancePlanService.GetAll());

        }

        [HttpGet]
        public async Task<ActionResult<ResponseMaintenancePlan>> GetById(Guid id)
        {
            return Ok(await _maintenancePlanService.GetById(id));

        }

        [HttpGet]
        public async Task<ActionResult<ResponseMaintenancePlan>> GetListByCenter(Guid id)
        {
            return Ok(await _maintenancePlanService.GetListByCenterId(id));

        }
        [HttpGet]
        public async Task<ActionResult<ResponseMaintenancePlan>> GetListByCenterAndVehicle(Guid id, Guid vehicleId)
        {
            return Ok(await _maintenancePlanService.GetListByCenterIdAndVehicleId(id, vehicleId));

        }

        [HttpGet]
        public async Task<ActionResult<ResponseMaintenancePlan>> GetListFilterCenterAndVehicle(Guid id, Guid vehicleId)
        {
            return Ok(await _maintenancePlanService.GetListFilterCenterAndVehicle(id, vehicleId));

        }

        [HttpPost]
        public async Task<ActionResult<ResponseMaintenancePlan>> Post(CreateMaintanancePlan maintenancePlan)
        {
            return Ok(await _maintenancePlanService.Create(maintenancePlan));

        }




    }
}
