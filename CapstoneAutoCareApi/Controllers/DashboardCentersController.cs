
using Domain.Entities;
using Infrastructure.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DashboardCentersController : ControllerBase
    {
        private readonly ICenterService _centerService;

        public DashboardCentersController(ICenterService centerService)
        {
            _centerService = centerService;
        }

        [HttpGet]
        public async Task<IActionResult> TotalGetListByStatusAndStatusCostService(Guid centerId)
        {
            return Ok(await _centerService.TotalGetListByStatusAndStatusCostService(centerId));
        }
        [HttpGet]
        public async Task<IActionResult> TotalGetListByStatusAndStatusCostSparePart(Guid centerId)
        {
            return Ok(await _centerService.TotalGetListByStatusAndStatusCostSpartPart(centerId));
        }
        [HttpGet]
        public async Task<IActionResult> TotalGetListByStatusPaidReceipt(Guid centerId)
        {
            return Ok(await _centerService.TotalGetListByStatusPaidReceipt(centerId));
        }
        [HttpGet]
        public async Task<IActionResult> TotalGetListByMainInfor(Guid centerId)
        {
            return Ok(await _centerService.TotalGetListByMainInfor(centerId));
        }
    }
}
