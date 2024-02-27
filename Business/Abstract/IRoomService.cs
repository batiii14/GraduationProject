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
        void Update(Room room);
        List<Room> GetAll();
        Room GetById(int id);
    }
}
