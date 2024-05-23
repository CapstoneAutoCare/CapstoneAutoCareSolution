using Infrastructure.IService;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SparePartController : ControllerBase
    {
       private readonly ISparePartsService _sparePartService;
        public SparePartController(ISparePartsService sparePartService)
        {
            _sparePartService = sparePartService;
        }
    }
}
