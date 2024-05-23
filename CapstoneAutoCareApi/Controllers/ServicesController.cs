using Infrastructure.IService;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ServicesController : Controller
    {
       private readonly IServiceCaresService _services;
        public ServicesController(IServiceCaresService services)
        {
            _services = services;
        }
    }
}
