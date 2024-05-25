using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RoomManager : IRoomService
    {
        private IRoomDal _roomDal;

        public RoomManager(IRoomDal roomDal)
        {
            _roomDal=roomDal;
        }
        public void Add(Room room)
        {
            _roomDal.Add(room);
        }

        public void Delete(int id)
        {
            var room=_roomDal.Get(p=>p.RoomId == id);
            _roomDal.Delete(room);
        }

        public List<Room> GetAll()
        {
            return _roomDal.GetList().ToList();
        }

        public Room GetById(int id)
        {
            return _roomDal.Get(p => p.RoomId == id);

        }

        public void Update(int roomId,
                       int dormitoryId,
                       String roomType = null,
                       double? price = null,
                       DateTime? createdAt = null,
                       DateTime? updatedAt = null)
        {
            var roomToUpdate = _roomDal.Get(p => p.RoomId == roomId);

            if (roomType != null)
                roomToUpdate.RoomType = roomType;
            if (dormitoryId != null)
                roomToUpdate.DormitoryId = dormitoryId;
            if (price != null)
                roomToUpdate.Price = price.Value;
            if (createdAt != null)
                roomToUpdate.CreatedAt = createdAt.Value;
            if (updatedAt != null)
                roomToUpdate.UpdatedAt = updatedAt.Value;

            _roomDal.Update(roomToUpdate);
        }
    }
}
