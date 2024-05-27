using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentService _studentService;
        INotificationService _notificationService;
        IEmailSenderService _emailSenderService;

        public StudentController(IStudentService studentService, INotificationService notificationService, IEmailSenderService emailSenderService)
        {
            _studentService = studentService;
            _notificationService = notificationService;
            _emailSenderService = emailSenderService;
        }

        [HttpPost("add")]
        public IActionResult Add(Student student)
        {
            student.UserType = "student";
            student.isEmailVerified = false;
            student.CreatedAt = DateTime.Now;
            student.UpdatedAt = DateTime.Now;
            _studentService.Add(student);
            _emailSenderService.SendEmailAsync(student.Email, "Email Verification Deneme", "Merhaba "+student.Name+" Doğrulama kodun burada: ",student.UserId);
            return Ok(student);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var students = _studentService.GetAll();
            return Ok(students);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var studentToDelete = _studentService.GetById(id);
            _studentService.Delete(id);
            return Ok(studentToDelete);
        }

        [HttpPut("update")]
        public IActionResult Put(int userId,
                   string? studentNumber,
                   string? department,
                   string? gender,
                   string? emergencyContactNo,
                   string? name,
                   string? surName,
                   string? email,
                   string? password,
                   string? address,
                   string? phoneNo,
                   DateTime? dob,
                   DateTime? createdAt,
                   DateTime? updatedAt,
                   string? profileUrl)
        {
            var studentToUpdate = _studentService.GetById(userId);
            studentToUpdate.UpdatedAt = DateTime.Now;

            _studentService.Update(userId,studentNumber,department,gender,emergencyContactNo,name,surName,email,password,address,phoneNo,dob,createdAt,updatedAt,profileUrl);
            studentToUpdate = _studentService.GetById(userId);
            return Ok(studentToUpdate);
        }

        [HttpGet("VievStudentProfileInfo")]
        public IActionResult GetStudentProfileInfo(int id)
        {
            var student=_studentService.GetById(id);
            return Ok(student);

        }

        [HttpGet("GetNotificationByStudentId")]
        public IActionResult ViewNotifications(int studentId)
        {
            var notification = _notificationService.GetNotificationByStudentId(studentId);
            return Ok(notification);
        }

        [HttpGet("getStudentById")]
        public IActionResult Get(int id)
        {

            var student = _studentService.GetById(id);
            return Ok(student);
        }

        [HttpGet("getStudentByName")]
        public IActionResult Get(string name)
        {

            var student = _studentService.GetStudentByName(name);
            return Ok(student);
        }
    }
}
