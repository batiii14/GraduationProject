using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DormitoryOwnerController : ControllerBase
    {
        IDormitoryOwnerService _dormitoryOwnerService;

        public DormitoryOwnerController(IDormitoryOwnerService dormitoryOwnerService)
        {
            _dormitoryOwnerService = dormitoryOwnerService;
        }

        [HttpPost("add")]
        public IActionResult Add(DormitoryOwner dormitoryOwner)
        {
            _dormitoryOwnerService.Add(dormitoryOwner); 
            return Ok(dormitoryOwner);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var dormitoryOwners=_dormitoryOwnerService.GetAll();
            return Ok(dormitoryOwners);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var dormitoryOwnerToDelete=_dormitoryOwnerService.GetById(id);
            _dormitoryOwnerService.Delete(id);
            return Ok(dormitoryOwnerToDelete);
        }

        [HttpPut("update")]
        public IActionResult Put(int id)
        {
            var dormitoryOwnerToUpdate = _dormitoryOwnerService.GetById(id);
            return Ok(dormitoryOwnerToUpdate);
        }

        [HttpGet("getDormitoryOwnerById")]
        public IActionResult Get(int id)
        {

            var dormitoryOwner = _dormitoryOwnerService.GetById(id);
            return Ok(dormitoryOwner);
        }
    }
}
