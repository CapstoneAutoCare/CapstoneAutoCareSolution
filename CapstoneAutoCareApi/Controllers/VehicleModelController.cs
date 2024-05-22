using Infrastructure.Common.Request.VehicleModel;
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
        [HttpGet("Get All")]
        public async Task<IActionResult> GetAllVehicleModels()
        {
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> GetVehicleModelByID(Guid it)
        {
            return NoContent();
        }
        [HttpPut("Status")] 
        public async Task<IActionResult> UpdateStatus(Guid id, string status)
        {
            return NotFound();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateVehicleModel(Guid id, UpdateVehicleModel model)
        {
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> CreateVehicleModels(CreateVehicleModel createVehicleModel)
        {
            return NotFound();
        }
    }
}
