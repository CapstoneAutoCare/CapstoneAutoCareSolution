using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Application;
using Domain.Entities;
using Infrastructure.Common.Request;
using Infrastructure.IService;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        private readonly IPackageService _packageService;

        public PackagesController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Package>>> GetPackages()
        {
            return Ok(await _packageService.GetAll());
        }

        [HttpGet]
        public async Task<ActionResult<Package>> GetPackage(Guid id)
        {
            return Ok(await _packageService.GetById(id));

        }
        [HttpPost]
        public async Task<ActionResult<Package>> PostPackage(CreatePackage package)
        {
            return Ok(await _packageService.Create(package));
        }

    }
}
