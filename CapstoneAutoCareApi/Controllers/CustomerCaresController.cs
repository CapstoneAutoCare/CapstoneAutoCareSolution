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
using Microsoft.AspNetCore.Authorization;
using Infrastructure.Common.Response.ResponseCustomerCare;

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
        public async Task<ActionResult<IEnumerable<ResponseCustomerCare>>> GetAll()
        {
            return Ok(await _customerCareService.GetAll());
        }

        [HttpGet]
        public async Task<ActionResult<ResponseCustomerCare>> GetById(Guid id)
        {
            return Ok(await _customerCareService.GetCustomerCareById(id));
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<ResponseCustomerCare>>> GetListByCenter(Guid centerId)
        {
            return Ok(await _customerCareService.GetListByCenter(centerId));
        }

        //[HttpPut]
        //public async Task<IActionResult> PutCustomerCare(Guid id, CustomerCare customerCare)
        //{

        //    return NoContent();
        //}

        [HttpPost]
        public async Task<ActionResult<ResponseCustomerCare>> Post(CreateCustomerCare customerCare)
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
