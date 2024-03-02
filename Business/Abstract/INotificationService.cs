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
        void Update(Notification notification);
        List<Notification> GetAll();
        Notification GetById(int id);
        Notification GetNotificationByStudentId(int studentId);
    }
}
