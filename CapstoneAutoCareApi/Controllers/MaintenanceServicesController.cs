using Infrastructure.IService;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MaintenanceServicesController : ControllerBase
    {
    private readonly IMaintananceServicesService _service;
        public MaintenanceServicesController(IMaintananceServicesService service)
        {
            _service = service;
        }
    }
}
