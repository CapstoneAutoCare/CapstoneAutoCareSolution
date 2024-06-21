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
using Infrastructure.Common.Response.ResponseCost;
using Infrastructure.Common.Request.RequestSparePartsItemCost;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SparePartsItemCostsController : ControllerBase
    {
        private readonly ISparePartsItemCostService _sparePartsItemCostService;

        public SparePartsItemCostsController(ISparePartsItemCostService sparePartsItemCostService)
        {
            _sparePartsItemCostService = sparePartsItemCostService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseSparePartsItemCost>>> GetAll()
        {
            return Ok(await _sparePartsItemCostService.GetAll());
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseSparePartsItemCost>>> GetListByClient(Guid centerId)
        {
            return Ok(await _sparePartsItemCostService.GetListByVIEWClient(centerId));

        }
        [HttpGet]
        public async Task<ActionResult<ResponseSparePartsItemCost>> GetById(Guid id)
        {
            return Ok(await _sparePartsItemCostService.GetById(id));
        }
        
        [HttpPatch]
        public async Task<ActionResult<ResponseSparePartsItemCost>> PatchStatus(Guid id, string status)
        {
            return Ok(await _sparePartsItemCostService.UpdateStatus(id, status));
        }

        [HttpPost]
        public async Task<ActionResult<ResponseSparePartsItemCost>> Post(CreateSparePartsItemCost sparePartsItemCost)
        {
            return Ok(await _sparePartsItemCostService.Create(sparePartsItemCost));
        }

        //[HttpDelete]
        //public async Task<IActionResult> DeleteSparePartsItemCost(Guid id)
        //{

        //    return NoContent();
        //}

    }
}
