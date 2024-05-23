using Infrastructure.Common.Request.MaintananceServices;
using Infrastructure.Common.Request.MaintenanceSchedule;
using Infrastructure.Common.Response.ReponseServicesCare;
using Infrastructure.Common.Response.ReponseVehicleModel;
using Infrastructure.IService;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MaintenanceServicesController : ControllerBase
    {
        private readonly IMaintananceServicesService _service;
        public MaintenanceServicesController(IMaintananceServicesService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<ResponseMaintananceServices>>> GetAll()
        {
            return Ok(await _service.GetAll());
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _service.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateMaintananceServices create)
        {
            return Ok(await _service.Create(create));
        }

    }
}
