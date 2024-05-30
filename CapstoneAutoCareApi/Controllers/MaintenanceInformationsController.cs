using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Application;
using Domain.Entities;
using Infrastructure.Common.Response.ResponseMaintenanceInformation;
using Infrastructure.Common.Request.MaintenanceInformation;
using Infrastructure.IService;
using Infrastructure.Common.Request.RequestMaintenanceInformation;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MaintenanceInformationsController : ControllerBase
    {
        private readonly IMaintenanceInformationService _maintenanceInformationService;

        public MaintenanceInformationsController(IMaintenanceInformationService maintenanceInformationService)
        {
            _maintenanceInformationService = maintenanceInformationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseMaintenanceInformation>>> GetAll()
        {
            return Ok(await _maintenanceInformationService.GetAll());
        }

        [HttpGet]
        public async Task<ActionResult<ResponseMaintenanceInformation>> GetById(Guid id)
        {
            return Ok(await _maintenanceInformationService.GetById(id));
        }



        [HttpPost]
        public async Task<ActionResult<ResponseMaintenanceInformation>> Post([FromBody] CreateMaintenanceInformation maintenanceInformation)
        {
            return Ok(await _maintenanceInformationService.Create(maintenanceInformation));
        }
        [HttpPost]
        public async Task<ActionResult<ResponseMaintenanceInformation>> PostHaveItems([FromBody] CreateMaintenanceInformationHaveItems maintenanceInformation)
        {
            return Ok(await _maintenanceInformationService.CreateHaveItems(maintenanceInformation));
        }

    }
}
