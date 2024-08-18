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
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Infrastructure.Common.Response.ReponseVehicleModel;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MaintenanceCentersController : ControllerBase
    {
        private readonly ICenterService _centerService;

        public MaintenanceCentersController(ICenterService centerService)
        {
            _centerService = centerService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaintenanceCenter>>> GetAll()
        {
            return Ok(await _centerService.GetAll());
        }

        [HttpGet]
        public async Task<ActionResult<MaintenanceCenter>> GetById(Guid id)
        {
            return Ok(await _centerService.GetById(id));
        }

        [HttpGet]
        public async Task<ActionResult<MaintenanceCenter>> GetAllStatusActive()
        {
            return Ok(await _centerService.GetAllActive());
        }
        [HttpPatch]
        public async Task<ActionResult<ResponseCenter>> UpdateStatus(Guid id, string status)
        {
            return Ok(await _centerService.UpdateStatus(id, status));
        }

        [HttpPost]
        public async Task<ActionResult<MaintenanceCenter>> Post(CreateCenter create)
        {
            return Ok(await _centerService.Create(create));
        }

        [HttpPut]
        public async Task<ActionResult<MaintenanceCenter>> Update(Guid centerId, UpdateCenter center)
        {
            return Ok(await _centerService.Update(centerId, center));
        }


    }
}
