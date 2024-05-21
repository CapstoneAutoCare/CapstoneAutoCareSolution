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

        public AdminsController(IAdminService adminService)
        {
            _adminService = adminService;
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
        public async Task<IActionResult> PutAdmin(Guid id, UpdateAdmin admin)
        {
            return Ok(_adminService.UpdateAdmin(id, admin));
        }

        [HttpPost]
        public async Task<ActionResult<Admin>> PostAdmin(CreateAdmin admin)
        {
            return Ok(await _adminService.CreateAdmin(admin));
        }

        [HttpPatch]
        public async Task<IActionResult> ChangeStatus(Guid id, string status)
        {
            return Ok(await _adminService.ChangeStatusAdmin(id, status));

        }


    }
}
