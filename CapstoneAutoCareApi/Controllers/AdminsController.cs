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
using Infrastructure.Common.Request.RequestAccount;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly ICustomerService _customerService;

        public AdminsController(IAdminService adminService, ICustomerService customerService)
        {
            _adminService = adminService;
            _customerService = customerService;
        }



        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Admin>>> GetAdmins()
        //{
        //}

        //[HttpGet]
        //public async Task<ActionResult<Admin>> GetAdmin(Guid id)
        //{
        //    return id;
        //}

        [HttpPut]
        public async Task<IActionResult> PutAdmin(Guid id, Admin admin)
        {

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Admin>> PostAdmin(CreateAdmin admin)
        {
            return Ok(await _adminService.CreateAdmin(admin));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAdmin(Guid id)
        {
            return NoContent();

        }


    }
}
