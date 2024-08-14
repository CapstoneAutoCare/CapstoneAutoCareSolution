using Infrastructure.Common.Request.MaintananceServices;
using Infrastructure.Common.Request.MaintenanceSchedule;
using Infrastructure.Common.Request.RequestMaintananceServices;
using Infrastructure.Common.Request.Sparepart;
using Infrastructure.Common.Response.ReponseVehicleModel;
using Infrastructure.Common.Response.ResponseServicesCare;
using Infrastructure.Common.Response.ResponseSparePart;
using Infrastructure.IService;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<ResponseMaintananceServices>>> GetListByCenter()
        {
            return Ok(await _service.GetListByCenter());
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<ResponseMaintananceServices>>> GetListByCenterId(Guid id)
        {
            return Ok(await _service.GetListByCenterId(id));
        }
        [HttpGet]
        public async Task<ActionResult<List<ResponseMaintananceServices>>> test(Guid id)
        {
            return Ok(await _service.Test(id));
        }
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<List<ResponseMaintananceServices>>> GetListPackageByOdoAndCenterId(Guid id, Guid odoId)
        {
            return Ok(await _service.GetListPackageByOdoAndCenterId(id, odoId));
        }
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<List<ResponseMaintananceServices>>> GetListPackageAndOdoTRUEByCenterId(Guid id)
        {
            return Ok(await _service.GetListPackageAndOdoTRUEByCenterId(id));
        }
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<List<ResponseMaintananceServices>>> GetListPackageAndOdoTRUEByCenterIdAndVehicleModelId(Guid id, Guid modelId)
        {
            return Ok(await _service.GetListPackageAndOdoTRUEByCenterIdAndModelId(id, modelId));
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ResponseMaintananceServices>> Post( CreateMaintananceServices create)
        {
            return Ok(await _service.Create(create));
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ResponseMaintananceServices>> PostList(CreateMainServiceList create)
        {
            return Ok(await _service.CreateList(create));
        }
        [HttpPut]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateMaintananceServices update)
        {
            return Ok(await _service.Update(id, update));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateStatus(Guid id, string status)
        {
            return Ok(await _service.UpdateStatus(id, status));
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(Guid id)
        {
            await _service.Remove(id);
            return Ok("Sucess");
        }
    }
}
