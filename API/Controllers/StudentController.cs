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

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost("add")]
        public IActionResult Add(Student student)
        {
            _studentService.Add(student);
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
        public IActionResult Put(int id)
        {
            var studentToUpdate = _studentService.GetById(id);

            return Ok(studentToUpdate);
        }

        [HttpGet("VievStudentProfileInfo")]
        public IActionResult GetStudentProfileInfo(int id)
        {
            var student=_studentService.GetById(id);
            return Ok(student);

        }
    }
}
