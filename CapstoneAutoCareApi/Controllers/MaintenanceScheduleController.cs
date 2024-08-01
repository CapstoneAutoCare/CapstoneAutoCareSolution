using Infrastructure.Common.Request.MaintenanceSchedule;
using Infrastructure.Common.Request.Sparepart;
using Infrastructure.Common.Request.VehicleModel;
using Infrastructure.Common.Response.ReponseVehicleModel;
using Infrastructure.IService;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MaintenanceScheduleController : ControllerBase
    {
        private readonly IMaintenanceScheduleService _maintenanceScheduleService;
        public MaintenanceScheduleController(IMaintenanceScheduleService maintenanceScheduleService)
        {
            _maintenanceScheduleService = maintenanceScheduleService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ReponseVehicleModels>>> GetAll()
        {
            return Ok(await _maintenanceScheduleService.GetAll());
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _maintenanceScheduleService.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateMaintenanceSchedule createMS)
        {
            return Ok(await _maintenanceScheduleService.Create(createMS));
        }
        [HttpPut]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateMaintananceSchedule update)
        {
            return Ok(await _maintenanceScheduleService.Update(id, update));
        }
        //[HttpPut]
        //public async Task<IActionResult> UpdateStatus(Guid id, string status)
        //{
        //    return Ok(await _maintenanceScheduleService.UpdateStatus(id, status));
        //}
    }
}
