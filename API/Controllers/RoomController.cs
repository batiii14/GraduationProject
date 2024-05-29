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

        [HttpGet("getRoomByDormitoryId")]
        public IActionResult GetByDormitoryId(int dormId)
        {

            var rooms = _roomService.GetAllByDormitoryId(dormId);
            return Ok(rooms);
        }
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }


        [HttpPost("add")]
        public IActionResult Add(Room room)
        {
            room.CreatedAt = DateTime.Now;
            room.UpdatedAt = DateTime.Now;
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
        public IActionResult Update(int roomId,
                       int dormitoryId,
                       String roomType,
                       double? price,
                       DateTime? createdAt,
                       DateTime? updatedAt)
        {
            var roomToUpdate = _roomService.GetById(roomId);
            _roomService.Update(roomId,
                        dormitoryId,
                        roomType,
                        price,
                        createdAt,
                        updatedAt);
            roomToUpdate=_roomService.GetById(roomId);
            roomToUpdate.UpdatedAt = DateTime.Now;

            return Ok(roomToUpdate);
        }

        [HttpGet("getRoomById")]
        public IActionResult Get(int id)
        {

            var room = _roomService.GetById(id);
            return Ok(room);
        }
    }
}
