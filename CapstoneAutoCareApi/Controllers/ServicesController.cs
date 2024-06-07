using Infrastructure.Common.Request.MaintananceServices;
using Infrastructure.Common.Request.MaintenanceSchedule;
using Infrastructure.Common.Request.Sparepart;
using Infrastructure.Common.Response.ReponseServicesCare;
using Infrastructure.Common.Response.ReponseVehicleModel;
using Infrastructure.IService;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ServicesController : Controller
    {
        private readonly IServiceCaresService _services;
        public ServicesController(IServiceCaresService services)
        {
            _services = services;
        }
        [HttpGet]
        public async Task<ActionResult<List<ResponseServicesCare>>> GetAll()
        {
            return Ok(await _services.GetAll());
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _services.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateServicesCare create)
        {
            return Ok(await _services.Create(create));
        }
        [HttpPut]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateServies update)
        {
            return Ok(await _services.Update(id, update));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateStatus(Guid id, string status)
        {
            return Ok(await _services.UpdateStatus(id, status));
        }
    }
}
