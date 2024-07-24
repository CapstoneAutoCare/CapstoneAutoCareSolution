using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Application;
using Domain.Entities;
using Infrastructure.Common.Response.ReceiptResponse;
using Infrastructure.Common.Request.ReceiptRequest;
using Infrastructure.IService;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReceiptsController : ControllerBase
    {
        private readonly IReceiptsService _receiptsService;

        public ReceiptsController(IReceiptsService receiptsService)
        {
            _receiptsService = receiptsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseReceipts>>> GetAll()
        {
            return Ok(await _receiptsService.GetAll());
        }

        [HttpGet]
        public async Task<ActionResult<ResponseReceipts>> GetById(Guid id)
        {
            return Ok(await _receiptsService.GetById(id));

        }
        [HttpGet]
        public async Task<ActionResult<ResponseReceipts>> GetByInforId(Guid id)
        {
            return Ok(await _receiptsService.GetByInforId(id));

        }
        [HttpPost]
        public async Task<ActionResult<ResponseReceipts>> Post(CreateReceipt receipt)
        {
            return Ok(await _receiptsService.Create(receipt));
        }
        [HttpPatch]
        public async Task<ActionResult<ResponseReceipts>> ChangeStatus(Guid id, string status)
        {
            return Ok(await _receiptsService.ChangeStatus(id, status));
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(Guid id)
        {
            await _receiptsService.Remove(id);
            return Ok("Success");
        }

    }
}
