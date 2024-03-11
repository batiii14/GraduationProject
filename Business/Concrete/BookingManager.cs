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

        public void Update(int BookingId,
                          int UserId,
                          int DormitoryId,
                          int RoomId,
                          String Status,
                          DateTime CreatedAt,
                          DateTime UpdatedAt)
        {
            var bookingToUpdate = _bookingDal.Get(b => b.BookingId == BookingId);

            if (UserId != null)
                bookingToUpdate.UserId = UserId;
            if (DormitoryId != null)
                bookingToUpdate.DormitoryId = DormitoryId;
            if (RoomId != null)
                bookingToUpdate.RoomId = RoomId;
            if (Status != null)
                bookingToUpdate.Status = Status;
            if (CreatedAt != null)
                bookingToUpdate.CreatedAt = CreatedAt;
            if (UpdatedAt != null)
                bookingToUpdate.UpdatedAt = UpdatedAt;

            _bookingDal.Update(bookingToUpdate);
        }

    }
}
