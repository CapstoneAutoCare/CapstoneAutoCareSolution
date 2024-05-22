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
    public class CustomerCaresController : ControllerBase
    {
        private readonly ICustomerCareService _customerCareService;

        public CustomerCaresController(ICustomerCareService customerCareService)
        {
            _customerCareService = customerCareService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerCare>>> GetCustomerCares()
        {
            return Ok(await _customerCareService.GetAll());
        }

        [HttpGet]
        public async Task<ActionResult<CustomerCare>> GetCustomerCare(Guid id)
        {
            return Ok(await _customerCareService.GetCustomerCareById(id));
        }

        //[HttpPut]
        //public async Task<IActionResult> PutCustomerCare(Guid id, CustomerCare customerCare)
        //{

        //    return NoContent();
        //}

        [HttpPost]
        public async Task<ActionResult<CustomerCare>> PostCustomerCare(CreateCustomerCare customerCare)
        {
            return Ok(await _customerCareService.CreateCustomerCare(customerCare));
        }

        //[HttpDelete]
        //public async Task<IActionResult> DeleteCustomerCare(Guid id)
        //{


        //    return NoContent();
        //}


    }
}
