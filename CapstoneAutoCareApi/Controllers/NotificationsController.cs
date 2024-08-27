using Domain.Entities;
using Infrastructure.IService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CapstoneAutoCareApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationSerivce _notificationSerivce;

        public NotificationsController(INotificationSerivce notificationSerivce)
        {
            _notificationSerivce = notificationSerivce;
        }

        [HttpGet]
        public async Task<ActionResult<List<Notification>>> GetAll()
        {
            return Ok(await _notificationSerivce.GetAll());
        }

        [HttpGet]
        public async Task<ActionResult<List<Notification>>> GetListByAccount(Guid id)
        {
            return Ok(await _notificationSerivce.GetListbyAccount(id));
        }

        [HttpPatch]
        public async Task<ActionResult<List<Notification>>> UpdateRead (Guid id)
        {
            return Ok(await _notificationSerivce.UpdateRead(id));
        }


    }
}
