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
    public class BookingManager : IBookingService
    {
        private IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public void Add(Booking booking)
        {
           _bookingDal.Add(booking);    
        }

        public void Delete(int id)
        {
            var bookingToDelete=_bookingDal.Get(p=>p.BookingId== id);
            _bookingDal.Delete(bookingToDelete);
        }

        public List<Booking> GetAll()
        {
            return _bookingDal.GetList().ToList();
        }

        public Booking GetById(int id)
        {
            var booking = _bookingDal.Get(p => p.BookingId == id);
            return booking;
        }

        public void Update(Booking booking)
        {
            throw new NotImplementedException();
        }
    }
}
