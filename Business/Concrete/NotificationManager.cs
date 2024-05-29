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
    public class NotificationManager : INotificationService
    {
        private INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }
        public void Add(Notification notification)
        {
            _notificationDal.Add(notification);
        }

        public void Delete(int id)
        {
            var notification=_notificationDal.Get(p=>p.NotificationId==id);
            _notificationDal.Delete(notification);
        }

        public List<Notification> GetAll()
        {
            return _notificationDal.GetList().ToList();
        }

        public Notification GetById(int id)
        {
            return _notificationDal.Get(p => p.NotificationId == id);

        }

        public void Update(int notificationId,
                               int recieverId,
                               int senderId,
                               String title = null,
                               String description = null,
                               String imageUrl = null,
                               DateTime? createdAt = null,
                               DateTime? updatedAt = null
                               )
        {
            var notificationToUpdate = _notificationDal.Get(p => p.NotificationId == notificationId);

            notificationToUpdate.RecieverId = recieverId;
            notificationToUpdate.SenderId = senderId;
            if (title != null)
                notificationToUpdate.Title = title;
            if (description != null)
                notificationToUpdate.Description = description;
            if (imageUrl != null)
                notificationToUpdate.ImageUrl = imageUrl;
            if (createdAt != null)
                notificationToUpdate.CreatedAt = createdAt.Value;
            if (updatedAt != null)
                notificationToUpdate.UpdatedAt = updatedAt.Value;



            _notificationDal.Update(notificationToUpdate);
        }

        public List<Notification> GetNotificationByStudentId(int studentId)
        {
            Notification _notification = new Notification();
            List<Notification> notifications = new List<Notification>();
            var notificationList = _notificationDal.GetList().ToList();
            foreach (var notification in notificationList)
            {
                if (notification.RecieverId == studentId)
                {
                    _notification = notification;
                    notifications.Add(notification);

                }

            }
            if (_notification == null)
            {
                throw new Exception("Kullanıcıya ait bir bildirim yok");
            }

            return notifications;
        }

        public void SendNotificationToAllByDormId(int dormId, Notification notification)
        {
            IBookingDal bookingDal = new BookingDal();

            foreach (var item in bookingDal.GetList())
            {
                if (item.DormitoryId == dormId)
                {
                    Notification notification1 = new Notification();
                    notification1.Title = notification.Title;
                    notification1.SenderId = notification.SenderId;
                    notification1.RecieverId = item.UserId;
                    notification1.ImageUrl = "";
                    notification1.Description = notification.Description;
                    notification1.Seen = notification.Seen;
                    _notificationDal.Add(notification1);

                }
            }
        }
    }
}
