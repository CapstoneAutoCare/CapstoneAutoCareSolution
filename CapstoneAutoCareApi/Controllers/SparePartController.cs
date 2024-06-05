using Infrastructure.Common.Request.MaintenanceSchedule;
using Infrastructure.Common.Request.Sparepart;
using Infrastructure.Common.Response.ReponseSparePart;
using Infrastructure.Common.Response.ReponseVehicleModel;
using Infrastructure.IService;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SparePartController : ControllerBase
    {
        private readonly ISparePartsService _sparePartService;
        public SparePartController(ISparePartsService sparePartService)
        {
            _sparePartService = sparePartService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ResponseSparePart>>> GetAll()
        {
            return Ok(await _sparePartService.GetAll());
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _sparePartService.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateSpareParts create)
        {
            return Ok(await _sparePartService.Create(create));
        }
        [HttpPut]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateSparePart update)
        {
            return Ok(await _sparePartService.Update(id, update));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateStatus(Guid id, string status)
        {
            return Ok(await _sparePartService.UpdateStatus(id, status));
        }
    }
}
