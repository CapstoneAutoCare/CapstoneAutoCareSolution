using Domain.Entities;
using Infrastructure.Common.Request.MaintenanceSchedule;
using Infrastructure.Common.Request.RequestSparepart;
using Infrastructure.Common.Request.Sparepart;
using Infrastructure.Common.Response.ReponseVehicleModel;
using Infrastructure.Common.Response.ResponseCost;
using Infrastructure.Common.Response.ResponseSparePart;
using Infrastructure.IService;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<ResponseSparePartsItem>>> GetListByCenter()
        {
            return Ok(await _sparePartsItemService.GetListByCenter());
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<ResponseSparePartsItem>>> GetListByCenterId(Guid id)
        {
            return Ok(await _sparePartsItemService.GetListByCenterId(id));
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ResponseSparePartsItem>> Post([FromBody] CreateSparePartsItem create)
        {
            return Ok(await _sparePartsItemService.Create(create));
        }
        [HttpPost]
        [Authorize]

        public async Task<ActionResult<ResponseSparePartsItem>> PostList(CreateListSparePartItem create)
        {
            return Ok(await _sparePartsItemService.CreateList(create));
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
        [HttpDelete]
        public async Task<IActionResult> Remove(Guid id)
        {
            await _sparePartsItemService.Remove(id);
            return Ok("Sucess");
        }
    }
}
