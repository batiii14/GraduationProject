using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMessageService
    {
        void Add(Message message);
        void Delete(int id);
        void Update(int MessageId, int SenderId, int ReciverId, String? MessageContent, DateTime? CreatedAt, DateTime? UpdatedAt);
        List<Message> GetAll();
        Message GetById(int id);
        List<Message> GetAllMessagesByStudentId(int studentId);
    }
}
