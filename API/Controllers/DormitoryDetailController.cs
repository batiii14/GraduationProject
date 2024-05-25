using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.Text.Json;

namespace API.Controllers
{
    public class DormitoryImageUploadDto
    {
        public int DetailId { get; set; }
        public IFormFile ImageFile { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class DormitoryDetailController : ControllerBase
    {
        private readonly IDormitoryDetailService _dormitoryDetailService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public DormitoryDetailController(IDormitoryDetailService dormitoryDetailService, IWebHostEnvironment hostingEnvironment)
        {
            _dormitoryDetailService = dormitoryDetailService;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost("add")]
        public IActionResult Add(DormitoryDetail dormitoryDetail)
        {
            dormitoryDetail.ImageUrlsJson = "";
            _dormitoryDetailService.Add(dormitoryDetail);
            dormitoryDetail.CreatedAt = DateTime.Now;
            dormitoryDetail.UpdatedAt = DateTime.Now;
            return Ok(dormitoryDetail);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var dormitoryDetails = _dormitoryDetailService.GetAll();
            return Ok(dormitoryDetails);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var dormDetailToDelete = _dormitoryDetailService.GetById(id);
            _dormitoryDetailService.Delete(id);
            return Ok(dormDetailToDelete);
        }

        [HttpPut("update")]
        public IActionResult Update(int DetailId, int DormitoryId, string ContactNo, string Email, string FaxNo, string Address, int Capacity, string Description, string InternetSpeed, bool HasKitchen, bool HasCleanService, bool HasShowerAndToilet, bool HasBalcony, bool HasTv, bool HasMicrowave, bool HasAirConditioning, DateTime CreatedAt, DateTime UpdatedAt)
        {
            var dormDetailToUpdate = _dormitoryDetailService.GetById(DetailId);
            _dormitoryDetailService.Update(DetailId, DormitoryId, ContactNo, Email, FaxNo, Address, Capacity, Description, InternetSpeed, HasKitchen, HasCleanService, HasShowerAndToilet, HasBalcony, HasTv, HasMicrowave, HasAirConditioning, CreatedAt, UpdatedAt);
            dormDetailToUpdate = _dormitoryDetailService.GetById(DetailId);
            dormDetailToUpdate.UpdatedAt = DateTime.Now;

            return Ok(dormDetailToUpdate);
        }

        [HttpGet("getDormitoryDetailById")]
        public IActionResult Get(int id)
        {
            var dormitoryDetail = _dormitoryDetailService.GetById(id);
            return Ok(dormitoryDetail);
        }

        [HttpGet("getDormitoryDetailByDormitoryId")]
        public IActionResult GetDormitoryDetailByDormitoryId(int id)
        {
            var dormitoryDetail = _dormitoryDetailService.GetByDormitoryId(id);
            return Ok(dormitoryDetail);
        }

        [HttpPost("uploadImage")]
        public async Task<IActionResult> UploadImage([FromForm] DormitoryImageUploadDto dto)
        {
            try
            {
                if (dto.ImageFile == null || dto.ImageFile.Length == 0)
                    return BadRequest("Image is null or empty");

                string imageUrl = $"/uploads/{dto.ImageFile.FileName}";

                var dormitoryDetail = _dormitoryDetailService.GetById(dto.DetailId);
                if (dormitoryDetail == null)
                    return NotFound("DormitoryDetail not found");

                if (string.IsNullOrEmpty(_hostingEnvironment.WebRootPath))
                    return StatusCode(500, "Server configuration error: WebRootPath is not set.");

                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                if (!Directory.Exists(uploads))
                    Directory.CreateDirectory(uploads);

                var filePath = Path.Combine(uploads, dto.ImageFile.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await dto.ImageFile.CopyToAsync(fileStream);
                }
                
                Console.WriteLine($"ImageUrlsJson before update: {dormitoryDetail.ImageUrlsJson}");

                List<string> imageUrls = new List<string>();
                if (!string.IsNullOrEmpty(dormitoryDetail.ImageUrlsJson))
                {
                    try
                    {
                        imageUrls = JsonSerializer.Deserialize<List<string>>(dormitoryDetail.ImageUrlsJson);
                    }
                    catch (JsonException ex)
                    {
                        Console.WriteLine($"Error deserializing ImageUrlsJson: {ex.Message}");
                        return BadRequest("Error parsing ImageUrlsJson");
                    }
                }
                imageUrls.Add(imageUrl);
                dormitoryDetail.ImageUrlsJson = JsonSerializer.Serialize(imageUrls);

                _dormitoryDetailService.updateModel(dormitoryDetail);

                return Ok(dormitoryDetail);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }


        [HttpGet("getImages")]
        public IActionResult GetImages(int detailId)
        {
            var dormitoryDetail = _dormitoryDetailService.GetById(detailId);
            if (dormitoryDetail == null)
                return NotFound("DormitoryDetail not found");

            // Deserialize the JSON string back into a list of URLs
            var imageUrls = JsonSerializer.Deserialize<List<string>>(dormitoryDetail.ImageUrlsJson);

            return Ok(imageUrls);
        }
    }
}
