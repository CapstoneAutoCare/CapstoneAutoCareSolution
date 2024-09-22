using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Application;
using Domain.Entities;
using Infrastructure.Common.Request.RequestMainVehicleDetail;
using Infrastructure.IService;
using Infrastructure.Common.Response.ResponseMVD;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MaintenanceVehiclesDetailsController : ControllerBase
    {
        private readonly IMaintenanceVehiclesDetailService _maintenanceVehiclesDetailService;


        public MaintenanceVehiclesDetailsController(IMaintenanceVehiclesDetailService maintenanceVehiclesDetailService)
        {
            _maintenanceVehiclesDetailService = maintenanceVehiclesDetailService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseMaintenanceVehicleDetail>>> GetAll()
        {
            return Ok(await _maintenanceVehiclesDetailService.GetAll());

        }

        [HttpGet]
        public async Task<ActionResult<List<ResponseMaintenanceVehicleDetail>>> GetListByVehicleId(Guid vehicleId)
        {
            return Ok(await _maintenanceVehiclesDetailService.GetListByVehicleId(vehicleId));
        }
        [HttpGet]
        public async Task<ActionResult<ResponseMaintenanceVehicleDetail>> GetById(Guid id)
        {
            return Ok(await _maintenanceVehiclesDetailService.GetById(id));
        }
        [HttpGet]
        public async Task<ActionResult<List<ResponseMaintenanceVehicleDetail>>> GetListByPlanAndVehicleAndCenter(Guid planId, Guid vehicleId, Guid centerId)
        {
            return Ok(await _maintenanceVehiclesDetailService.GetListByPlanAndVehicleAndCenter(planId, vehicleId, centerId));
        }
        //TEST

        [HttpGet]
        public async Task<ActionResult<ResponseMaintenanceVehicleDetail>> GetListByPlanAndVehicleAndCenterWithStatusFinished(Guid planId, Guid vehicleId, Guid centerId)
        {
            return Ok(await _maintenanceVehiclesDetailService.GetListByPlanAndVehicleAndCenterWithStatusFinished(planId, vehicleId, centerId));
        }
        [HttpPost]
        public async Task<ActionResult<ResponseMaintenanceVehicleDetail>> Post(CreateMainVehicleDetail maintenanceVehiclesDetail)
        {
            return Ok(await _maintenanceVehiclesDetailService.Create(maintenanceVehiclesDetail));

        }

    }
}
