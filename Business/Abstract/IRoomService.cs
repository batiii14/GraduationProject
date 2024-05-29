using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRoomService
    {
        void Add(Room room);
        void Delete(int id);
        List<Room> GetAllByDormitoryId(int dormitoryId);
        void Update(int roomId,
                       int dormitoryId,
                       String roomType,
                       double? price,
                       DateTime? createdAt,
                       DateTime? updatedAt);
        List<Room> GetAll();
        Room GetById(int id);
    }
}
