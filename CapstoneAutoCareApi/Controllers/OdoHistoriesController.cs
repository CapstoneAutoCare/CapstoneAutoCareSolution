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
using Infrastructure.Common.Response.OdoResponse;
using Infrastructure.Common.Request.RequestOdo;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OdoHistoriesController : ControllerBase
    {
        private readonly IOdoHistoryService _historyService;

        public OdoHistoriesController(IOdoHistoryService historyService)
        {
            _historyService = historyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseOdoHistory>>> GetAll()
        {
            return Ok(await _historyService.GetAll());
        }

        [HttpGet]
        public async Task<ActionResult<ResponseOdoHistory>> GetOdoHistory(Guid id)
        {
            return Ok(await _historyService.GetById(id));

        }
        [HttpPost]
        public async Task<ActionResult<ResponseOdoHistory>> Post(CreateOdoHistory odoHistory)
        {
            return Ok(await _historyService.Create(odoHistory));
        }
        [HttpPatch]
        public async Task<ActionResult<ResponseOdoHistory>> Patch(Guid id, UpdateOdo odoHistory)
        {
            return Ok(await _historyService.Update(id, odoHistory));
        }


    }
}
