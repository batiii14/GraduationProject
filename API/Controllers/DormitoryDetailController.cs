using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DormitoryDetailController : ControllerBase
    {
        IDormitoryDetailService _dormitoryDetailService;

        public DormitoryDetailController(IDormitoryDetailService dormitoryDetailService)
        {
            _dormitoryDetailService = dormitoryDetailService;
        }

        [HttpPost("add")]
        public IActionResult Add(DormitoryDetail dormitoryDetail)
        {
            _dormitoryDetailService.Add(dormitoryDetail);
            return Ok(dormitoryDetail);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var dormitoryDetails= _dormitoryDetailService.GetAll();
            return Ok(dormitoryDetails);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var dormDetailToDelete=_dormitoryDetailService.GetById(id);
            _dormitoryDetailService.Delete(id);
            return Ok(dormDetailToDelete);
        }

        [HttpPut("update")]
        public IActionResult Put(int id)
        {
            var dormDetailToUpdate = _dormitoryDetailService.GetById(id);
            return Ok(dormDetailToUpdate);
        }
    }
}
