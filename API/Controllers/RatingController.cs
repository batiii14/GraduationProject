using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {

        IRatingService _ratingService;
        IBookingService _bookingService;
        IDormitoryService _dormitoryService;

        public RatingController(IRatingService ratingService, IBookingService bookingService, IDormitoryService _dormitoryService)
        {
            _ratingService = ratingService;
            _bookingService = bookingService;
            _dormitoryService = _dormitoryService;
        }

        [HttpPost("add")]
        public IActionResult Add(Rating rating)
        {
            rating.CreatedAt = DateTime.Now;
            rating.UpdatedAt = DateTime.Now;
            _ratingService.Add(rating);
            return Ok(rating);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var ratings = _ratingService.GetAll();
            return Ok(ratings);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var ratingToDelete = _ratingService.GetById(id);
            _ratingService.Delete(id);
            return Ok(ratingToDelete);
        }

        [HttpPut("update")]
        public IActionResult Update(int ratingId, int dormitoryId, int userId, int ratingNo, DateTime? createdAt, DateTime? updatedAt)
        {
            var ratingToUpdate = _ratingService.GetById(ratingId);
            _ratingService.Update( ratingId, dormitoryId,userId,  ratingNo,  createdAt,  updatedAt);
            ratingToUpdate = _ratingService.GetById(ratingId);
            ratingToUpdate.UpdatedAt = DateTime.Now;

            return Ok(ratingToUpdate);
        }

        [HttpPost("AddRatingToDormitory")]
        public IActionResult PostRatingToDormitoryByUserId(Rating rating)
        {
            var bookingHistories = _bookingService.GetAll();
            List<Booking> bookings = new List<Booking>();
            foreach (var booking in bookingHistories)
            {
                if (booking.UserId == rating.UserId)
                {
                    _ratingService.Add(rating);
                }

            }
            return Ok(rating);
        }

        [HttpGet("getRatingById")]
        public IActionResult Get(int id)
        {

            var rating = _ratingService.GetById(id);
            return Ok(rating);
        }

        [HttpGet("getRatingByDormitoryId")]
        public IActionResult GetRatingByDormitoryId(int id)
        {
            var rating = _ratingService.GetRatingByDormitoryId(id);
            return Ok(rating);
        }
    }
}
