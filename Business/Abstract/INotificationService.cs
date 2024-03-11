using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface INotificationService
    {
        void Add(Notification notification);
        void Delete(int id);
        void Update(int notificationId, int recieverId, int senderId,String title,string description,String imageUrl,DateTime? createdAt,DateTime? updatedAt);
        List<Notification> GetAll();
        Notification GetById(int id);
        Notification GetNotificationByStudentId(int studentId);
    }
}
