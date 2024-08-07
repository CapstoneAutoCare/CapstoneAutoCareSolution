﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Application;
using Domain.Entities;
using Infrastructure.Common.Response.ResponseCost;
using Infrastructure.Common.Request.RequestMaintenanceServiceCost;
using Infrastructure.IService;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MaintenanceServiceCostsController : ControllerBase
    {
        private readonly IMaintananceServicesCostService _maintananceServicesCost;

        public MaintenanceServiceCostsController(IMaintananceServicesCostService maintananceServicesCost)
        {
            _maintananceServicesCost = maintananceServicesCost;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseMaintenanceServiceCost>>> GetAll()
        {
            return Ok(await _maintananceServicesCost.GetAll());

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseMaintenanceServiceCost>>> GetListByClient(Guid centerId)
        {
            return Ok(await _maintananceServicesCost.GetListByVIEWClient(centerId));

        }
        [HttpGet]
        public async Task<ActionResult<ResponseSparePartsItemCost>> GetByIdMaintenanceServiceActive(Guid id)
        {
            return Ok(await _maintananceServicesCost.GetByIdMaintenanceServiceActive(id));

        }
        [HttpGet]
        public async Task<ActionResult<ResponseMaintenanceServiceCost>> GetById(Guid id)
        {
            return Ok(await _maintananceServicesCost.GetById(id));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseSparePartsItemCost>>> GetListByDifMaintenanceServiceAndInforIdAndBooleanFalse(Guid centerId, Guid inforId)
        {
            return Ok(await _maintananceServicesCost.GetListByDifMaintenanceServiceAndInforIdAndBooleanFalse(centerId, inforId));
        }
        [HttpPost]
        public async Task<ActionResult<MaintenanceServiceCost>> Post(CreateMaintenanceServiceCost maintenanceServiceCost)
        {
            return Ok(await _maintananceServicesCost.Create(maintenanceServiceCost));

        }
        [HttpPatch]
        public async Task<ActionResult<ResponseMaintenanceServiceCost>> PatchStatus(Guid id, string status)
        {
            return Ok(await _maintananceServicesCost.UpdateStatus(id, status));
        }

       

        //[HttpDelete]
        //public async Task<IActionResult> DeleteMaintenanceServiceCost(Guid id)
        //{
        //    return NotFound();
        //}

    }
}
