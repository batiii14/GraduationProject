﻿using Business.Abstract;
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
        public IActionResult Put(int UserId, int DormitoryId, String Name, String SurName, String Email, String Password, String Address, String PhoneNo, DateTime CreatedAt, DateTime UpdatedAt, DateTime Dob, String ProfileUrl)
        {

            var dormitoryOwnerToUpdate = _dormitoryOwnerService.GetById(UserId);
            _dormitoryOwnerService.Update(UserId, DormitoryId, Name, SurName, Email, Password, Address, PhoneNo, CreatedAt, UpdatedAt, Dob, ProfileUrl);
            dormitoryOwnerToUpdate = _dormitoryOwnerService.GetById(UserId);
            return Ok(dormitoryOwnerToUpdate);
        }
    }
}
