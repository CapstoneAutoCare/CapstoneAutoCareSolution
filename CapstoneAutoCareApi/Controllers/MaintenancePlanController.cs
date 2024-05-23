using Infrastructure.IService;
using Infrastructure.IService.Imp;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MaintenancePlanController : ControllerBase
    {
        private readonly IMaintenancePlanService _maintainPlanService;
        public MaintenancePlanController(IMaintenancePlanService maintenancePlanService)
        {
            _maintainPlanService = maintenancePlanService;
        }

    }
}
