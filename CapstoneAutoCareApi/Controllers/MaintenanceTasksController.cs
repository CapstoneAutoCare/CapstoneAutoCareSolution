using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.IService;
using Infrastructure.Common.Response.ResponseTechnicanMain;
using Infrastructure.Common.Request.RequestMaintenanceTechinican;
using Microsoft.AspNetCore.Authorization;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MaintenanceTasksController : ControllerBase
    {

        private readonly IMaintenanceTechinicanService _maintenanceTechinicanService;

        public MaintenanceTasksController(IMaintenanceTechinicanService maintenanceTechinicanService)
        {
            _maintenanceTechinicanService = maintenanceTechinicanService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseMaintenanceTask>>> GetAll()
        {
            return Ok(await _maintenanceTechinicanService.GetAll());
        }

        [HttpGet]
        public async Task<ActionResult<ResponseMaintenanceTask>> GetById(Guid id)
        {
            return Ok(await _maintenanceTechinicanService.GetById(id));
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ResponseMaintenanceTask>>> GetListByCenter()
        {
            return Ok(await _maintenanceTechinicanService.GetListByCenter());
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ResponseMaintenanceTask>>> GetListByCenterId(Guid id)
        {
            return Ok(await _maintenanceTechinicanService.GetListByCenterId(id));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseMaintenanceTask>>> GetListByCustomerCare()
        {
            return Ok(await _maintenanceTechinicanService.GetListByCustomerCare());
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseMaintenanceTask>>> GetListByTech()
        {
            return Ok(await _maintenanceTechinicanService.GetListByTechnician());
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseMaintenanceTask>>> GetListByInfor(Guid id)
        {
            return Ok(await _maintenanceTechinicanService.GetListByInforId(id));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseMaintenanceTask>>> GetListStatusDifCancelledByInfor(Guid id)
        {
            return Ok(await _maintenanceTechinicanService.GetListStatusDifCancelledByInfor(id));
        }
        [HttpPost]
        public async Task<ActionResult<ResponseMaintenanceTask>> Post(CreateMaintenanceTechinican technician)
        {
            return Ok(await _maintenanceTechinicanService.Create(technician));

        }
        [HttpPatch]
        public async Task<ActionResult<ResponseMaintenanceTask>> Patch(Guid id, string status)
        {
            return Ok(await _maintenanceTechinicanService.UpdateStatus(id, status));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _maintenanceTechinicanService.Remove(id);
            return Ok("success");
        }

    }
}
