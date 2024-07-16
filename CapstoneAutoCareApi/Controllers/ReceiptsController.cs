//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Application;
//using Domain.Entities;
//using Infrastructure.Common.Response.ReceiptResponse;
//using Infrastructure.Common.Request.ReceiptRequest;
//using Infrastructure.IService;

//namespace CapstoneAutoCareApi.Controllers
//{
//    [Route("api/[controller]/[action]")]
//    [ApiController]
//    public class ReceiptsController : ControllerBase
//    {
//        private readonly IReceiptsService _receiptsService;

//        public ReceiptsController(IReceiptsService receiptsService)
//        {
//            _receiptsService = receiptsService;
//        }

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<ResponseReceipts>>> GetAll()
//        {
//            return Ok(await _receiptsService.GetAll());
//        }

//        [HttpGet]
//        public async Task<ActionResult<ResponseReceipts>> GetById(Guid id)
//        {
//            return Ok(await _receiptsService.GetById(id));

//        }

//        //[HttpPut]
//        //public async Task<ActionResult<ResponseReceipts>> Put(Guid id, Receipt receipt)
//        //{
//        //}

//        [HttpPost]
//        public async Task<ActionResult<ResponseReceipts>> Post(CreateReceipt receipt)
//        {
//            return Ok(await _receiptsService.Create(receipt));
//        }

//        //[HttpDelete]
//        //public async Task<IActionResult> Remove(Guid id)
//        //{
//        //}

//    }
//}
