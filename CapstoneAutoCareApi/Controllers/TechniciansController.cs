﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Application;
using Domain.Entities;
using Infrastructure.IService;
using Infrastructure.Common.Request.RequestAccount;
using Infrastructure.Common.Response.ResponseStaffCare;
using Infrastructure.Common.Response.ResponseCustomerCare;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TechniciansController : ControllerBase
    {
        private readonly ITechnicianService _technicianService;

        public TechniciansController(ITechnicianService staffCareService)
        {
            _technicianService = staffCareService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseTechnician>>> GetAll()
        {
            return Ok(await _technicianService.GetAll());
        }

        [HttpGet]
        public async Task<ActionResult<ResponseTechnician>> GetById(Guid id)
        {
            return Ok(await _technicianService.GetById(id));

        }
        [HttpGet]
        public async Task<ActionResult<ResponseTechnician>> GetListByCenter(Guid centerId)
        {
            return Ok(await _technicianService.GetListByCenter(centerId));

        }
        //[HttpPut]
        //public async Task<IActionResult> PutStaffCare(Guid id, StaffCare staffCare)
        //{

        //    return NoContent();
        //}

        [HttpPost]
        public async Task<ActionResult<ResponseTechnician>> Post(CreateTechnician staffCare)
        {
            return Ok(await _technicianService.Create(staffCare));
        }

        [HttpPut]
        public async Task<ActionResult<ResponseTechnician>> Update(Guid techId, UpdateTechi techi)
        {
            return Ok(await _technicianService.Update(techId, techi));
        }

    }
}
