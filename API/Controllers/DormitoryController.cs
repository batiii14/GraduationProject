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
            _dormitoryService.Add(dormitory);
            return Ok(dormitory);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var dormitories=_dormitoryService.GetAll();
            return Ok(dormitories);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var dormitoryToDelete=_dormitoryService.GetById(id);
            _dormitoryService.Delete(id);
            return Ok(dormitoryToDelete);
        }

        [HttpPut("update")]
        public IActionResult Put(int DormitoryId, String Name, int UniversityId, int Quota, DateTime CreatedAt, DateTime UpdatedAt)
        {

            var dormitoryToUpdate = _dormitoryService.GetById(DormitoryId);
            _dormitoryService.Update(DormitoryId, Name, UniversityId, Quota, CreatedAt, UpdatedAt);
            dormitoryToUpdate = _dormitoryService.GetById(DormitoryId);
            return Ok(dormitoryToUpdate);

        }
    }
}
