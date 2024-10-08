﻿using Domain.Entities;
using Infrastructure.Common.Request.RequestVehicleBrandRequest;
using Infrastructure.IService;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VehicleBrandController : Controller
    {
        private readonly IVehicleBrandService _vehicleBrandService;
        public VehicleBrandController(IVehicleBrandService vehicleBrandService)
        {
            _vehicleBrandService = vehicleBrandService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _vehicleBrandService.GetAllVehiclesBrand());
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _vehicleBrandService.GetVehiclesBrandByID(id));
        }
        [HttpGet]
        public async Task<IActionResult> GetNotInCenter(Guid id)
        {
            return Ok(await _vehicleBrandService.GetBrandsNotInCenter(id));
        }

        [HttpPost]
        public async Task<ActionResult<VehiclesBrand>> Post(CreateBrand create)
        {
            return Ok(await _vehicleBrandService.CreateVehicleBrand(create));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllActive()
        {
            return Ok(await _vehicleBrandService.GetListBrandActive());
        }
        //[HttpPut]
        //public async Task<IActionResult> UpdateStatus(Guid id, string status)
        //{
        //    return NotFound();
        //}
        //[HttpPut]
        //public async Task<IActionResult> UpdateBrand(Guid id, VehicleBrandUpdate brandName)
        //{
        //    return NotFound();
        //}
    }
}
