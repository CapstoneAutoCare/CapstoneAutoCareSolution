﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Application;
using Domain.Entities;
using Infrastructure.IService;
using Infrastructure.Common.Request.RequestVehicles;
using Infrastructure.Common.Response.ResponseBooking;
using Microsoft.AspNetCore.Authorization;
using Infrastructure.Common.Response.VehiclesResponse;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {

        private readonly IVehiclesService _vehiclesService;

        public VehiclesController(IVehiclesService vehiclesService)
        {
            _vehiclesService = vehiclesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseVehicles>>> GetAll()
        {
            return Ok(await _vehiclesService.GetAll());

        }

        [HttpGet]
        public async Task<ActionResult<ResponseVehicles>> GetById(Guid id)
        {

            return Ok(await _vehiclesService.GetById(id));
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<ResponseVehicles>>> GetListByClient()
        {
            return Ok(await _vehiclesService.GetListByClient());
        }
        [HttpGet]
        public async Task<ActionResult<List<ResponseVehicles>>> GetListByCenterWhenBuyPackage(Guid centerId)
        {
            return Ok(await _vehiclesService.GetListByCenterWhenBuyPackage(centerId));
        }

        [HttpPost]
        public async Task<ActionResult<ResponseVehicles>> Post(CreateVehicle vehicles)
        {
            return Ok(await _vehiclesService.Create(vehicles));
        }
        [HttpPatch]
        public async Task<ActionResult<ResponseVehicles>> Patch(Guid id, string status)
        {

            return Ok(await _vehiclesService.UpdateStatus(id, status));
        }
        [HttpPut]
        public async Task<ActionResult<ResponseVehicles>> PutVehicle(Guid id, UpdateVehicle vehicle)
        {

            return Ok(await _vehiclesService.Update(id, vehicle));
        }


    }
}
