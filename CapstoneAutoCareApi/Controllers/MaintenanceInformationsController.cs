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
using Application.Dashboard;

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
        public async Task<ActionResult<List<ResponseMaintenanceInformation>>> GetListByBookingId(Guid id)
        {
            return Ok(await _maintenanceInformationService.GetListByBookingId(id));
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<ResponseMaintenanceInformation>>> GetListByClient()
        {
            return Ok(await _maintenanceInformationService.GetListByClient());
        }
        [HttpGet]
        public async Task<ActionResult<List<ResponseMaintenanceInformation>>> GetByBookingIdAndScheduleIdAndVehicleId(Guid bookingId, Guid scheduleId, Guid vehicleId)
        {
            return Ok(await _maintenanceInformationService.GetByBookingIdAndScheduleIdAndVehicleId(bookingId, scheduleId, vehicleId));
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
        public async Task<ActionResult<List<ResponseMaintenanceInformation>>> GetByMvd(Guid id)
        {
            return Ok(await _maintenanceInformationService.GetByMVDId(id));
        }
        [HttpGet]
        public async Task<ActionResult<List<ResponseMaintenanceInformation>>> GetListGetMonthlyRevenueByCenterId(Guid id, int year)
        {
            return Ok(await _maintenanceInformationService.GetMonthlyRevenue(year, id));
        }
        [HttpGet]
        public async Task<ActionResult<List<MonthlyBookingSummary>>> GetListGetMonthlyBookingSummaryPAIDByCenterId(Guid id, int year)
        {
            return Ok(await _maintenanceInformationService.GetMonthlyRevenuePAID(year, id));
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<ResponseMaintenanceInformation>>> GetListByCenterAndStatus(string status)
        {
            return Ok(await _maintenanceInformationService.GetListByCenterAnd(status));
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<ResponseMaintenanceInformation>>> GetListByCenterAndStatusCheckinAndAnyTaskCancel(Guid centerId)
        {
            return Ok(await _maintenanceInformationService.GetListByCenterAndStatusCheckinAndTaskInactive(centerId));
        }
        [HttpGet]
        public async Task<ActionResult<List<ResponseMaintenanceInformation>>> GetListByPlanAndVehicleAndCenterAndStatusCREATEDBYClIENT(Guid planId, Guid vehicleId, Guid centerId)
        {
            return Ok(await _maintenanceInformationService.GetListByPlanAndVehicleAndCenterAndStatusCREATEDBYClIENT(planId, vehicleId, centerId));
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

        //[HttpPost]
        //public async Task<ActionResult<ResponseMaintenanceInformation>> PostMaintenance(CreateMaintenanceInformationHavePackage maintenanceInformation)
        //{
        //    return Ok(await _maintenanceInformationService.CreateMaintenance(maintenanceInformation));
        //}
        [HttpPost]
        public async Task<ActionResult<ResponseMaintenanceInformation>> PostMaintenance(CreateMainV1 maintenanceInformation)
        {
            return Ok(await _maintenanceInformationService.CreateMainV1(maintenanceInformation));
        }

        [HttpPatch]
        public async Task<ActionResult<ResponseMaintenanceInformation>> CHANGESTATUS(Guid id, string status)
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
