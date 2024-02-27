using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        INotificationService _notificationService;

        public NotificationController(
        INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost("add")]
        public IActionResult Add(Notification notification)
        {
            _notificationService.Add(notification);
            return Ok(notification);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var notifications= _notificationService.GetAll();
            return Ok(notifications);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var notToDelete= _notificationService.GetById(id);
            _notificationService.Delete(id);
            return Ok(notToDelete);
        }

        [HttpPut("update")]
        public IActionResult Put(int id)
        {
            var notToUpdate = _notificationService.GetById(id);
            return Ok(notToUpdate);
        }
    }
}
