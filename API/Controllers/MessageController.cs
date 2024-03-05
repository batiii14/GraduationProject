using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        IMessageService _messageService;
        INotificationService   _notificationService;

        public MessageController(IMessageService messageService, INotificationService notificationService)
        {
            _messageService = messageService;
            _notificationService = notificationService;
        }


        [HttpPost("add")]
        public IActionResult Add(Message message)
        {
            _messageService.Add(message);
            Notification notification = new Notification();
            notification.SenderId = message.SenderId;
            notification.RecieverId = message.ReciverId;
            notification.Title = "New Message";
            notification.CreatedAt = DateTime.Now;
            notification.UpdatedAt = DateTime.Now;
            notification.Description = "You've recieved new message";
            notification.Seen = false;
            notification.ImageUrl = "bilmemne.jpg";
            _notificationService.Add(notification);
            return Ok(message);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var messages= _messageService.GetAll();
            return Ok(messages);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var messageToDelete= _messageService.GetById(id);
            _messageService.Delete(id);
            return Ok(messageToDelete);
        }

        [HttpPut("update")]
        public IActionResult Put(int id)
        {
            var messageToUpdate = _messageService.GetById(id);

            return Ok(messageToUpdate);
        }

        [HttpGet("getAllMessagesByStudentId")]
        public IActionResult GetAllMessagesByStudentId(int studentId)
        {
            var messages=_messageService.GetAllMessagesByStudentId(studentId);
            return Ok(messages);
        }
    }
}
