using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DormitoryOwnerManager : IDormitoryOwnerService
    {

        private IDormitoryOwnerDal _dormitoryOwnerDal;

        public DormitoryOwnerManager(IDormitoryOwnerDal dormitoryOwnerDal)
        {
            _dormitoryOwnerDal = dormitoryOwnerDal;
        }
        public void Add(DormitoryOwner dormitoryOwner)
        {
            _dormitoryOwnerDal.Add(dormitoryOwner);
        }

        public void Delete(int id)
        {
            var dormOwner=_dormitoryOwnerDal.Get(p=>p.UserId == id);
            _dormitoryOwnerDal.Delete(dormOwner);
        }

        public List<DormitoryOwner> GetAll()
        {
            return _dormitoryOwnerDal.GetList().ToList();
        }

        public DormitoryOwner GetById(int id)
        {
            return _dormitoryOwnerDal.Get(p=>p.UserId == id);

        }

        public void Update(int UserId,
                      int DormitoryId,
                      String Name,
                      String SurName,
                      String Email,
                      String Password,
                      String Address,
                      String PhoneNo,
                      DateTime CreatedAt,
                      DateTime UpdatedAt,
                      DateTime Dob,
                      String ProfileUrl)
        {
            var userToUpdate = _dormitoryOwnerDal.Get(u => u.UserId == UserId);

            if (DormitoryId != null)
                userToUpdate.DormitoryId = DormitoryId;
            if (Name != null)
                userToUpdate.Name = Name;
            if (SurName != null)
                userToUpdate.SurName = SurName;
            if (Email != null)
                userToUpdate.Email = Email;
            if (Password != null)
                userToUpdate.Password = Password;
            if (Address != null)
                userToUpdate.Address = Address;
            if (PhoneNo != null)
                userToUpdate.PhoneNo = PhoneNo;
            if (CreatedAt != null)
                userToUpdate.CreatedAt = CreatedAt;
            if (UpdatedAt != null)
                userToUpdate.UpdatedAt = UpdatedAt;
            if (Dob != null)
                userToUpdate.Dob = Dob;
            if (ProfileUrl != null)
                userToUpdate.ProfileUrl = ProfileUrl;

            _dormitoryOwnerDal.Update(userToUpdate);
        }

        public DormitoryOwner GetDormitoryOwnerByName(string name)
        {
            var dormitoryOwner = _dormitoryOwnerDal.Get(p => p.Name.ToLower() == name.ToLower());

            return dormitoryOwner;
        }

        public List<Booking> GetAllBookingsForSpecificDormitory(int dormId)
        {
            IBookingDal bookingDal=new BookingDal();
            var bookingList=bookingDal.GetList().Where(p=>p.DormitoryId == dormId).ToList();
            return bookingList;

        }

        public List<Booking> GetPendingBookingsForSpecificDormitory(int dormId)
        {
            IBookingDal bookingDal = new BookingDal();
            var bookingList = bookingDal.GetList().Where(p => p.DormitoryId == dormId&&p.Status=="Pending").ToList();
            return bookingList;

        }

        public Boolean ApproveStudentsBookingRequest(int bookingId)
        {
            var result = false;
            try
            {
                IBookingDal bookingDal = new BookingDal();
                var booking = bookingDal.Get(p => p.BookingId == bookingId);
                booking.Status = "Approved";
                booking.UpdatedAt = DateTime.Now;
                bookingDal.Update(booking);
                result = true;
                Notification notification = new Notification();
                notification.SenderId = booking.DormitoryId;
                notification.RecieverId = booking.UserId;
                notification.Title = "You have a new notification";
                notification.UpdatedAt = DateTime.Now;
                notification.CreatedAt = DateTime.Now;
                notification.Seen = false;
                notification.Description = "Your booking has been approved";
                notification.ImageUrl = "asdasd";
                NotificationDal notificationDal = new NotificationDal();
                notificationDal.Add(notification);

            }
            catch (Exception)
            {

                throw new Exception("Something went wrong! We couldn't approve the booking request.");
            }
            return result;
            

        }
    }
}
