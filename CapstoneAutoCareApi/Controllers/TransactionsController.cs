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
using Infrastructure.Common.Response.ResponseStaffCare;
using Infrastructure.Common.Response;
using Infrastructure.Common.Payment;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseTransaction>>> GetAll()
        {
            return Ok(await _transactionService.GetAll());
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseTransaction>>> GetListByCenterAndStatusTransferred(Guid id)
        {
            return Ok(await _transactionService.GetListByCenterAndStatusTransferred(id));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseTransaction>>> GetListByClientRECEIVED(Guid id)
        {
            return Ok(await _transactionService.GetListByClientRECEIVED(id));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseTransaction>>> GetListByCenterId(Guid id)
        {
            return Ok(await _transactionService.GetListByCenterId(id));
        }
        [HttpGet]
        public async Task<ActionResult<ResponseTransaction>> GetById(Guid id)
        {
            return Ok(await _transactionService.GetById(id));
        }
        //TEST

        [HttpGet]
        public async Task<ActionResult<ResponseTransaction>> GetTransactionsByVehicleAndCenterAndPlan(Guid plan, Guid vehicle, Guid center)
        {
            return Ok(await _transactionService.GetTransactionsByVehicleAndCenterAndPlan(vehicle, center, plan));
        }

        [HttpPost]
        public async Task<ActionResult<ResponseTransaction>> Post(CreatePaymentTransaction transaction)
        {
            return Ok(await _transactionService.Create(transaction));
        }
    }
}
