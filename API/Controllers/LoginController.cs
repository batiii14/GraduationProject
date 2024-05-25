using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }


        [HttpGet]
        public ActionResult IsLoginValid(string email, string Password)
        { //Model bilgilerini dönder
            var result=_loginService.Login(email, Password);

            return Ok(result);
        }
    }
}
