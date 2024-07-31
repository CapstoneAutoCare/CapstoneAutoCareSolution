﻿using Domain.Entities;
using Infrastructure.Common.Request.MaintenanceSchedule;
using Infrastructure.Common.Request.RequestFb;
using Infrastructure.Common.Response.ResponseFb;
using Infrastructure.IService;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedBackService _feedbackService;

        public FeedbackController(IFeedBackService feedbackService)
        {
            _feedbackService = feedbackService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedBack>>> GetAll()
        {
            return Ok(await _feedbackService.GetAll());
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _feedbackService.GetById(id));
        }
        [HttpGet]
        public async Task<ActionResult<List<FeedBack>>> GetAllFeedBackByCenter()
        {
            return Ok(await _feedbackService.GetListByCenter());
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateFeedBack createFb)
        {
            return Ok(await _feedbackService.Create(createFb));
        }
        [HttpPut]
        public async Task<IActionResult> Update(Guid id, [FromBody] string update)
        {
            return Ok(await _feedbackService.Update(id, update));
        }
    }
}