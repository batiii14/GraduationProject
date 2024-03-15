using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
        IUniversityService _universityService;

        public UniversityController(
        IUniversityService universityService)
        {
            _universityService = universityService;

        }

        [HttpPost("add")]
        public IActionResult Add(University university)
        {
            university.CreatedAt = DateTime.Now;
            university.UpdatedAt = DateTime.Now;
            _universityService.Add(university);
            return Ok(university);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var universities = _universityService.GetAll();
            return Ok(universities);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var universityToDelete = _universityService.GetById(id);
            _universityService.Delete(id);
            return Ok(universityToDelete);
        }

        //[HttpPut("update")]
        //public IActionResult Update(int id)
        //{
        //    var universityToUpdate = _universityService.GetById(id);

        //    return Ok(universityToUpdate);
        //}

        [HttpPut("update")]
        public IActionResult UpdateUniversity(int id,
                     string? name,
                     string? address,
                     DateTime? createdAt,
                     DateTime? updatedAt)
        {
            var university = _universityService.GetById(id);

            if (university == null)
            {
                return NotFound();
            }
            university.UpdatedAt = DateTime.Now;

            _universityService.Update(id, name, address,createdAt,updatedAt);
            university = _universityService.GetById(id);
            return Ok(university);
        }

        [HttpGet("getUniversityById")]
        public IActionResult Get(int id)
        {

            var university = _universityService.GetById(id);
            return Ok(university);
        }

        [HttpGet("getUniversityByName")]
        public IActionResult Get(string name)
        {

            var university = _universityService.GetUniversityByName(name);
            return Ok(university);
        }
    }
}
