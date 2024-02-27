using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_adminService.GetAll());
        }

        [HttpPost("add")]
        public IActionResult Add(Admin admin)
        {
            admin.CreatedAt= DateTime.Now;
            admin.UpdatedAt= DateTime.Now;
            _adminService.Add(admin);
            return Ok(admin);

        }
    }
}
