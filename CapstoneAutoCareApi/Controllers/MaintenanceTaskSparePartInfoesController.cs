using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Application;
using Domain.Entities;
using Infrastructure.Common.Response.ResponseTechnicanMain;
using Infrastructure.IService;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MaintenanceTaskSparePartInfoesController : ControllerBase
    {
        private readonly IMaintenanceTaskSparePartInfoService _maintenanceTaskSparePartInfoService;

        public MaintenanceTaskSparePartInfoesController(IMaintenanceTaskSparePartInfoService maintenanceTaskSparePartInfoService)
        {
            _maintenanceTaskSparePartInfoService = maintenanceTaskSparePartInfoService;
        }


        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<MaintenanceTaskSparePartInfo>>> GetMaintenanceTaskSparePartInfos()
        //{
        //    return NotFound();

        //}

        //[HttpGet]
        //public async Task<ActionResult<MaintenanceTaskSparePartInfo>> GetMaintenanceTaskSparePartInfo(Guid id)
        //{
        //    return NotFound();

        //}

        [HttpPatch]
        public async Task<ActionResult<ResponseMainTaskSparePart>> PatchStatus(Guid id, string status)
        {
            return Ok(await _maintenanceTaskSparePartInfoService.ChangeStatus(id, status));
        }

        //[HttpPost]
        //public async Task<ActionResult<MaintenanceTaskSparePartInfo>> Post(MaintenanceTaskSparePartInfo maintenanceTaskSparePartInfo)
        //{
        //    return NoContent();

        //}

        //[HttpDelete]
        //public async Task<IActionResult> DeleteMaintenanceTaskSparePartInfo(Guid id)
        //{

        //    return NoContent();
        //}

    }
}
