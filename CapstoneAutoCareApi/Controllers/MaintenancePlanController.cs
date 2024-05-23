using Infrastructure.Common.Request.MaintenancePlan;
using Infrastructure.Common.Request.MaintenanceSchedule;
using Infrastructure.Common.Response.ReponseMaintenancePlan;
using Infrastructure.Common.Response.ReponseVehicleModel;
using Infrastructure.IService;
using Infrastructure.IService.Imp;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MaintenancePlanController : ControllerBase
    {
        private readonly IMaintenancePlanService _maintainPlanService;
        public MaintenancePlanController(IMaintenancePlanService maintenancePlanService)
        {
            _maintainPlanService = maintenancePlanService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ResponseMaintenancePlan>>> GetAll()
        {
            return Ok(await _maintainPlanService.GetAll());
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _maintainPlanService.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateMaintanancePlan create)
        {
            return Ok(await _maintainPlanService.Create(create));
        }

    }
}
