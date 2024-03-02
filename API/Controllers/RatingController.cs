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

        public RatingController(IRatingService ratingService, IBookingService bookingService)
        {
            _ratingService = ratingService;
            _bookingService = bookingService;
        }

        [HttpPost("add")]
        public IActionResult Add(Rating rating)
        {
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
            var ratingToDelete=_ratingService.GetById(id);
            _ratingService.Delete(id);
            return Ok(ratingToDelete);
        }

        [HttpPut("update")]
        public IActionResult Put(int id)
        {
            var ratingToUpdate = _ratingService.GetById(id);

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

    }
}
