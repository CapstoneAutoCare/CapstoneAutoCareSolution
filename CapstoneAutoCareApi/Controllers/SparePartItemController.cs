using Infrastructure.IService;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SparePartItemController : ControllerBase
    {
        private readonly ISparePartsItemService _sparePartsItemService;
        public SparePartItemController(ISparePartsItemService sparePartsItemService)
        {
            _sparePartsItemService = sparePartsItemService;
        }
    }
}
