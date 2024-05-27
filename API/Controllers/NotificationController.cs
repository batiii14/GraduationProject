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
            notification.CreatedAt = DateTime.Now;
            notification.UpdatedAt = DateTime.Now;
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
        public IActionResult Update(int notificationId, int recieverId, int senderId, String title, string description, String imageUrl, DateTime? createdAt, DateTime? updatedAt)
        {
            var notToUpdate = _notificationService.GetById(notificationId);
            _notificationService.Update(notificationId, recieverId, senderId, title, description, imageUrl, createdAt, updatedAt);
            notToUpdate= _notificationService.GetById(notificationId);
            notToUpdate.UpdatedAt = DateTime.Now;

            return Ok(notToUpdate);
        }


        [HttpGet("getAllNotificationByStudentId")]
        public IActionResult GetAllNotificationByStudentId(int studentId)
        {
            var notifications = _notificationService.GetNotificationByStudentId(studentId);
            return Ok(notifications);
        }

        [HttpGet("getNotificationById")]
        public IActionResult Get(int id)
        {

            var notification = _notificationService.GetById(id);
            return Ok(notification);
        }
    }
}
