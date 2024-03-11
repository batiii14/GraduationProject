﻿using Business.Abstract;
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
        public IActionResult Put(int DetailId, int DormitoryId, String ContactNo, String Email, String FaxNo, String Address, int Capacity, String Description, String InternetSpeed, Boolean HasKitchen, Boolean HasCleanService, Boolean HasShowerAndToilet, Boolean HasBalcony, Boolean HasTv, Boolean HasMicrowave, Boolean HasAirConditioning, List<String> PhotoUrls, DateTime CreatedAt, DateTime UpdatedAt)
        {

            var dormDetailToUpdate = _dormitoryDetailService.GetById(DetailId);
            _dormitoryDetailService.Update(DetailId, DormitoryId, ContactNo, Email, FaxNo, Address, Capacity, Description, InternetSpeed, HasKitchen, HasCleanService, HasShowerAndToilet, HasBalcony, HasTv, HasMicrowave, HasAirConditioning, PhotoUrls, CreatedAt, UpdatedAt);
            dormDetailToUpdate = _dormitoryDetailService.GetById(DetailId);
            return Ok(dormDetailToUpdate);

        }
    }
}
