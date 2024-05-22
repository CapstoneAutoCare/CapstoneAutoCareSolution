using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Application;
using Domain.Entities;
using Infrastructure.Common.Request.RequestAccount;
using Infrastructure.IService;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StaffCaresController : ControllerBase
    {
        private readonly IStaffCareService _staffCareService;

        public StaffCaresController(IStaffCareService staffCareService)
        {
            _staffCareService = staffCareService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StaffCare>>> GetAll()
        {
            return Ok(await _staffCareService.GetAll());
        }

        [HttpGet]
        public async Task<ActionResult<StaffCare>> GetById(Guid id)
        {
            return Ok(await _staffCareService.GetById(id));

        }

        //[HttpPut]
        //public async Task<IActionResult> PutStaffCare(Guid id, StaffCare staffCare)
        //{

        //    return NoContent();
        //}

        [HttpPost]
        public async Task<ActionResult<StaffCare>> PostStaffCare(CreateStaffCare staffCare)
        {
            return Ok(await _staffCareService.Create(staffCare));
        }

        //[HttpDelete]
        //public async Task<IActionResult> DeleteStaffCare(Guid id)
        //{
        //    return NoContent();
        //}

    }
}
