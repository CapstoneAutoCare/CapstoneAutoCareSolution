using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Application;
using Domain.Entities;
using Infrastructure.Common.Request.VMRequest;
using Infrastructure.IService;
using Infrastructure.Common.Response;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VehiclesMaintenancesController : ControllerBase
    {
        private readonly IVehiclesMaintenanceService _vehiclesMaintenanceService;

        public VehiclesMaintenancesController(IVehiclesMaintenanceService vehiclesMaintenanceService)
        {
            _vehiclesMaintenanceService = vehiclesMaintenanceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseVehiclesMaintenance>>> GetAll()
        {
            return Ok(await _vehiclesMaintenanceService.GetList()); 
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseVehiclesMaintenance>>> GetListByCenter(Guid id)
        {
            return Ok(await _vehiclesMaintenanceService.GetListByCenter(id));
        }

        [HttpPost]
        public async Task<ActionResult<ResponseVehiclesMaintenance>> Post(CreateVehicleMain vehiclesMaintenance)
        {
            return Ok(await _vehiclesMaintenanceService.CreateList(vehiclesMaintenance));

        }

    }
}
