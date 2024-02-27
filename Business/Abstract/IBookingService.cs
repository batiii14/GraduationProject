using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBookingService
    {
        void Add(Booking booking);
        void Delete(int id);
        void Update(Booking booking);
        List<Booking> GetAll();
        Booking GetById(int id);
    }
}
