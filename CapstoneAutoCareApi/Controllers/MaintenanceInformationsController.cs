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
using Infrastructure.Common.Request.RequestMaintenanceInformation;
using Infrastructure.Common.Response.ResponseMainInformation;
using Infrastructure.Common.Response.ResponseBooking;
using Microsoft.AspNetCore.Authorization;
using Domain.Enum;

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
        [HttpGet]
        public async Task<ActionResult<ResponseMaintenanceInformation>> GetByBookingId(Guid id)
        {
            return Ok(await _maintenanceInformationService.GetByBookingId(id));
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<ResponseMaintenanceInformation>>> GetListByClient()
        {
            return Ok(await _maintenanceInformationService.GetListByClient());
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<ResponseMaintenanceInformation>>> GetListByCenter()
        {
            return Ok(await _maintenanceInformationService.GetListByCenter());
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<ResponseMaintenanceInformation>>> GetListByCenterId(Guid id)
        {
            return Ok(await _maintenanceInformationService.GetListByCenterId(id));
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<ResponseMaintenanceInformation>>> GetListByCenterAndStatus(string status)
        {
            return Ok(await _maintenanceInformationService.GetListByCenterAnd(status));
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<ResponseMaintenanceInformation>>> GetListByCenterAndStatusCheckinAndAnyTaskCancel()
        {
            return Ok(await _maintenanceInformationService.GetListByCenterAndStatusCheckinAndTaskInactive());
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

        [HttpPatch]
        public async Task<ActionResult<ResponseMaintenanceInformation>> CHANGESTATUS(Guid id, string  status)
        {
            return Ok(await _maintenanceInformationService.ChangeStatus(id, status));
        }
        [HttpPatch]
        public async Task<ActionResult<ResponseMaintenanceInformation>> CHANGESTATUSBACKUP(Guid id, string status)
        {
            return Ok(await _maintenanceInformationService.ChangeStatusBackUp(id, status));
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(Guid id)
        {
            await _maintenanceInformationService.Remove(id);
            return Ok("Success");
        }
    }
}
