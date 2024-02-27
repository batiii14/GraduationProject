using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }


        [HttpPost("add")]
        public IActionResult Add(Room room)
        {
            _roomService.Add(room);
            return Ok(room);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var rooms = _roomService.GetAll();  
            return Ok(rooms);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var roomToDelete=_roomService.GetById(id);
            _roomService.Delete(id);
            return Ok(roomToDelete);
        }

        [HttpPut("update")]
        public IActionResult Put(int id)
        {
            var roomToUpdate = _roomService.GetById(id);

            return Ok(roomToUpdate);
        }
    }
}
