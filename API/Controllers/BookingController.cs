using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        IBookingService _bookingService;
        

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("GetBookingHistoryByStudentId")]
        public IActionResult GetBookingHistoryByStudentId(int studentId)
        {
            var bookingHistories=_bookingService.GetAll();
            List<Booking> bookings = new List<Booking>();
            foreach (var item in bookingHistories)
            {
                if (item.UserId == studentId)
                {
                    bookings.Add(item);
                }   
            }
            return Ok(bookings);
        }

        [HttpPost("add")]
        public IActionResult Add(Booking booking)
        {
            booking.CreatedAt = DateTime.Now;
            booking.UpdatedAt = DateTime.Now;
            _bookingService.Add(booking);
            return Ok(booking);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var bookings = _bookingService.GetAll();

            return Ok(bookings);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var bookingToDelete = _bookingService.GetById(id);
            _bookingService.Delete(id);

            return Ok(bookingToDelete);
        }

        [HttpPut("update")]
        public IActionResult Put(int id, int RoomId, String Status)
        {
            var bookingToUpdate = _bookingService.GetById(id);
            bookingToUpdate.Status = Status;
            bookingToUpdate.RoomId = RoomId;
            bookingToUpdate.UpdatedAt = DateTime.Now;
            return Ok(bookingToUpdate);
        }

        [HttpGet("getBookingById")]
        public IActionResult Get(int id)
        {

            var booking = _bookingService.GetById(id);
            return Ok(booking);
        }
    }
}
