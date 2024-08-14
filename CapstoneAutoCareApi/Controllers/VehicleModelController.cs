using Infrastructure.Common.Request.VehicleModel;
using Infrastructure.Common.Response.ReponseVehicleModel;
using Infrastructure.IService;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VehicleModelController : Controller
    {
        private readonly IVehicleModelService _VMService;
        public VehicleModelController(IVehicleModelService vehicleModelService)
        {
            _VMService = vehicleModelService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ReponseVehicleModels>>> GetAll()
        {
            return Ok(await _VMService.GetAllVehiclesModels());
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _VMService.GetVehicleById(id));
        }
        [HttpGet]
        public async Task<ActionResult<List<ReponseVehicleModels>>> GetListByBrandId(Guid id)
        {
            return Ok(await _VMService.GetListVehicleByBrandId(id));
        }
        //[HttpPut] 
        //public async Task<IActionResult> UpdateStatus(Guid id, string status)
        //{
        //    return NotFound();
        //}
        //[HttpPut]
        //public async Task<IActionResult> UpdateVehicleModel(Guid id, UpdateVehicleModel model)
        //{
        //    return NotFound();
        //}
        [HttpPost]
        public async Task<IActionResult> Post(CreateVehicleModel createVehicleModel)
        {
            return Ok(await _VMService.CreateNewVehicleModel(createVehicleModel));
        }
    }
}
