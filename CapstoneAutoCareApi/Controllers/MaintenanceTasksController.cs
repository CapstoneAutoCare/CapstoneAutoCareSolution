using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.IService;
using Infrastructure.Common.Response.ResponseTechnicanMain;
using Infrastructure.Common.Request.RequestMaintenanceTechinican;

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
        //[HttpDelete]
        //public async Task<IActionResult> Delete(Guid id)
        //{

        //    return NoContent();
        //}

    }
}
