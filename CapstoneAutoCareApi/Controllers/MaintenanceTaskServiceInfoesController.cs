//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Application;
//using Domain.Entities;

//namespace CapstoneAutoCareApi.Controllers
//{
//    [Route("api/[controller]/[action]")]
//    [ApiController]
//    public class MaintenanceTaskServiceInfoesController : ControllerBase
//    {
//        public MaintenanceTaskServiceInfoesController()
//        {
//        }

//        //[HttpGet]
//        //public async Task<ActionResult<IEnumerable<MaintenanceTaskServiceInfo>>> GetAll()
//        //{
//        //    return NotFound();

//        //}

//        //[HttpGet]
//        //public async Task<ActionResult<MaintenanceTaskServiceInfo>> GetById(Guid id)
//        //{
//        //    return NotFound();
//        //}

//        [HttpPatch]
//        public async Task<IActionResult> PatchStatus(Guid id, string status)
//        {
//            return NoContent();
//        }

//        //[HttpPost]
//        //public async Task<ActionResult<MaintenanceTaskServiceInfo>> Post(MaintenanceTaskServiceInfo maintenanceTaskServiceInfo)
//        //{
//        //    return NoContent();

//        //}

//        //[HttpDelete]
//        //public async Task<IActionResult> Remove(Guid id)
//        //{
//        //    return NoContent();
//        //}

//    }
//}
