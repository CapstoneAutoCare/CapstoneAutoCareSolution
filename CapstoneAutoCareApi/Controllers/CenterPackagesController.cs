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
using Infrastructure.Common.Response;
using Infrastructure.Common.Request;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CenterPackagesController : ControllerBase
    {
        private readonly IPackageCenterService _packageCenterService;

        public CenterPackagesController(IPackageCenterService packageCenterService)
        {
            _packageCenterService = packageCenterService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseCenterPackage>>> GetAll ()
        {
            return Ok(await _packageCenterService.GetAll());

        }

        [HttpGet]
        public async Task<ActionResult<ResponseCenterPackage>> GetCenterPackages(Guid id)
        {
            return Ok(await _packageCenterService.GetById(id));

        }

        [HttpPost]
        public async Task<ActionResult<CenterPackages>> PostCenterPackages(CreateCenterPackage centerPackages)
        {
            return Ok(await _packageCenterService.Create(centerPackages));
        }


    }
}
