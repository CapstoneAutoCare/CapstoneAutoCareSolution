using Infrastructure.Common.Request.VehicleRequest;
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
        [HttpGet("Get All")]
        public async Task<IActionResult> GetAll()
        {
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> GetByID(Guid id)
        {
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBrand(string brandName)
        {
            return NotFound();
        }
        [HttpPut("Update status")]
        public async Task<IActionResult> UpdateStatus(Guid id, string status)
        {
            return NotFound();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBrand(Guid id, VehicleBrandUpdate brandName)
        {
            return NotFound();
        }
    }
}
