using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DormitoryController : ControllerBase
    {
        IDormitoryService _dormitoryService;

        public DormitoryController(IDormitoryService dormitoryService)
        {
            _dormitoryService = dormitoryService;
        }

        [HttpPost("add")]
        public IActionResult Add(Dormitory dormitory)
        {
            dormitory.CreatedAt = DateTime.Now;
            dormitory.UpdatedAt = DateTime.Now;
            _dormitoryService.Add(dormitory);
            return Ok(dormitory);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var dormitories = _dormitoryService.GetAll();
            return Ok(dormitories);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var dormitoryToDelete = _dormitoryService.GetById(id);
            _dormitoryService.Delete(id);
            return Ok(dormitoryToDelete);
        }

        [HttpPut("update")]
        public IActionResult Put(int id)
        {
            var dormitoryToUpdate = _dormitoryService.GetById(id);
            dormitoryToUpdate.UpdatedAt = DateTime.Now;

            return Ok(dormitoryToUpdate);
        }

        [HttpGet("getDormitoryById")]
        public IActionResult Get(int id)
        {

            var dormitory = _dormitoryService.GetById(id);
            return Ok(dormitory);
        }


        [HttpGet("getDormitoryByName")]
        public IActionResult Get(string name)
        {

            var dormitory = _dormitoryService.GetDormitoryByName(name);
            return Ok(dormitory);
        }
    }
}
