using Business.Abstract;
using Entities.Concrete;
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

        [HttpGet("getAll")]
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

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var adminToDelete=_adminService.GetById(id);
            _adminService.Delete(id);
            return Ok(adminToDelete);
        }

        [HttpPut("update")]
        public IActionResult Update(int UserId, String Name,String SurName, String Email, String Password, String Address, String PhoneNo, DateTime? CreatedAt, DateTime? UpdatedAt, DateTime? Dob, String ProfileUrl)
        {
            var adminToUpdate = _adminService.GetById(UserId);
            _adminService.Update(UserId, Name,SurName, Email, Password, Address, PhoneNo, CreatedAt, UpdatedAt, Dob, ProfileUrl);
            adminToUpdate=_adminService.GetById(UserId);
            adminToUpdate.UpdatedAt= DateTime.Now;
            return Ok(adminToUpdate);
        }

        [HttpGet("getAdminById")]
        public IActionResult Get(int id)
        {

            var admin = _adminService.GetById(id);
            return Ok(admin);
        }

        [HttpGet("getAdminByName")]
        public IActionResult Get(string name)
        {

            var admin = _adminService.GetAdminByName(name);
            return Ok(admin);
        }
    }
}
