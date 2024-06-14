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
using System.Text.Json.Nodes;
using Infrastructure.Common.Response;
using System.Net;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
        //{
        //    return NotFound();

        //}
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<JsonArray>> Profile()
        {
            return Ok(await _accountService.Profile());
        }

        //[HttpPut]
        //public async Task<IActionResult> PutAccount(Guid id, Account account)
        //{

        //    return NoContent();
        //}

        [HttpPost]
        public async Task<ActionResult<AuthenResponseMessToken>> Login(string email, string password)
        {
            return Ok(new
            {
                Success = HttpStatusCode.OK,
                Message = "Success",
                Data = await _accountService.Login(email, password)
            });
        }

        //[HttpDelete]
        //public async Task<IActionResult> DeleteAccount(Guid id)
        //{
        //    return NoContent();
        //}

    }
}
