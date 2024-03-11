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
        public ActionResult IsLoginValid(string userName, string Password)
        { //Model bilgilerini dönder
            var result=_loginService.Login(userName, Password);

            return Ok(result);
        }

        
    }
}
