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
    public class SparePartItemController : ControllerBase
    {
        private readonly ISparePartsItemService _sparePartsItemService;
        public SparePartItemController(ISparePartsItemService sparePartsItemService)
        {
            _sparePartsItemService = sparePartsItemService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ResponseSparePartsItem>>> GetAll()
        {
            return Ok(await _sparePartsItemService.GetAll());
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _sparePartsItemService.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSparePartsItem create)
        {
            return Ok(await _sparePartsItemService.Create(create));
        }
        [HttpPut]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateSparePartItem update)
        {
            return Ok(await _sparePartsItemService.Update(id, update));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateStatus(Guid id, string status)
        {
            return Ok(await _sparePartsItemService.UpdateStatus(id, status));
        }
    }
}
