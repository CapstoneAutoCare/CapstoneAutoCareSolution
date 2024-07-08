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
using Infrastructure.Common.Response.ClientResponse;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {

        private readonly ICustomerService _customerService;

        public ClientsController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseClient>>> GetAll()
        {
            return Ok(await _customerService.GetAll());
        }

        [HttpGet]
        public async Task<ActionResult<ResponseClient>> GetById(Guid id)
        {
            return Ok(await _customerService.GetById(id));
        }

        //[HttpPut]
        //public async Task<IActionResult> PutClient(Guid id, Client client)
        //{
        //    return NoContent();
        //}

        [HttpPost]
        public async Task<ActionResult<ResponseClient>> Post(CreateClient client)
        {
            return Ok(await _customerService.CreateCustomer(client));
        }

        [HttpPut]
        public async Task<ActionResult<ResponseClient>> Update(Guid clientId, UpdateClient client)
        {
            return Ok(await _customerService.Update(clientId, client));
        }
    }
}
