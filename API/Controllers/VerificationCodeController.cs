using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerificationCodeController : ControllerBase
    {
        IVerificationCodeService _verificationCodeService;

        public VerificationCodeController(IVerificationCodeService verificationCodeService)
        {
            _verificationCodeService = verificationCodeService;
        }

        [HttpPost("add")]
        public IActionResult Add(VerificationCode verificationCode)
        {
            _verificationCodeService.Add(verificationCode);
            return Ok();
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var list = _verificationCodeService.GetAll();
            return Ok(list);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            _verificationCodeService.Delete(id);
            var toDelete = _verificationCodeService.GetById(id);
            return Ok(toDelete);
        }


        [HttpGet("getByStudentId")]
        public IActionResult GetByStudentId(int id)
        {
            var list = _verificationCodeService.GetAllByStudentId(id);
            return Ok(list);
        }

        [HttpPut("verifyUser")]
        public IActionResult VerifyUser(VerificationCode verificationCode)
        {
            var result = _verificationCodeService.verifyUser(verificationCode);
            return Ok(result);
        }




    }
}