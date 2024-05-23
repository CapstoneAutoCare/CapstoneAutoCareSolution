﻿using Infrastructure.Common.Request.MaintenanceSchedule;
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
        public async Task<ActionResult<List<ResponseVehicleModel>>> GetAll()
        {
            return Ok(await _sparePartsItemService.GetAll());
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _sparePartsItemService.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateMaintenanceSchedule createMS)
        {
            return Ok(await _sparePartsItemService.Create(createMS));
        }

    }
}
