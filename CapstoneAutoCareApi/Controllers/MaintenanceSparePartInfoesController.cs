using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Application;
using Domain.Entities;
using Infrastructure.IService;
using Infrastructure.Common.Request.RequestMaintenanceSparePartInfor;
using Infrastructure.Common.Response.ResponseMaintenanceSparePart;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MaintenanceSparePartInfoesController : ControllerBase
    {
        private readonly IMaintenanceSparePartInfoService _maintenanceSparePartInfoService;

        public MaintenanceSparePartInfoesController(IMaintenanceSparePartInfoService maintenanceSparePartInfoService)
        {
            _maintenanceSparePartInfoService = maintenanceSparePartInfoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseMaintenanceSparePartInfo>>> GetAll()
        {
            return Ok(await _maintenanceSparePartInfoService.GetAll());
        }

        [HttpGet]
        public async Task<ActionResult<ResponseMaintenanceSparePartInfo>> GetById(Guid id)
        {
            return Ok(await _maintenanceSparePartInfoService.GetById(id));

        }

        //[HttpPut]
        //public async Task<IActionResult> PutMaintenanceSparePartInfo(Guid id, MaintenanceSparePartInfo maintenanceSparePartInfo)
        //{
        //}

        [HttpPost]
        public async Task<ActionResult<ResponseMaintenanceSparePartInfo>> Post(CreateMaintenanceSparePartInfo maintenanceSparePartInfo)
        {
            return Ok(await _maintenanceSparePartInfoService.Create(maintenanceSparePartInfo));
        }
        [HttpPatch]
        public async Task<ActionResult<ResponseMaintenanceSparePartInfo>> PatchStatus(Guid id,string status)
        {
            return Ok(await _maintenanceSparePartInfoService.UpdateStatus(id,status));
        }

    }
}