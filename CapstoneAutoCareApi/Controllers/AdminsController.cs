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
using Microsoft.AspNetCore.Authorization;
using Infrastructure.Common.Request.RequestAccount;
using Infrastructure.Common.Response.ResponseAdmin;

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
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<ResponseAdmin>> GetProfileAdmin()
        {
            return Ok(await _adminService.GetByEmail());
        }

        [HttpPut]
        public async Task<IActionResult> Put(Guid id, UpdateAdmin admin)
        {
            return Ok(await _adminService.UpdateAdmin(id, admin));
        }

        [HttpPost]
        public async Task<ActionResult<Admin>> Post(CreateAdmin admin)
        {
            return Ok(await _adminService.CreateAdmin(admin));
        }

        [HttpPatch]
        public async Task<IActionResult> ChangeStatusCenter(Guid id, string status)
        {
            return Ok(await _adminService.ChangeStatusAdmin(id, status));

        }


    }
}
