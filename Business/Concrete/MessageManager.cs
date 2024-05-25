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
    public class MessageManager : IMessageService
    {
        private IMessageDal _messageDal;
        
        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
            

        }
        public void Add(Message message)
        {

            _messageDal.Add(message);
            

        }

        public void Delete(int id)
        {
            var message = _messageDal.Get(p => p.MessageId == id);
            _messageDal.Delete(message);
        }

        public List<Message> GetAll()
        {
            return _messageDal.GetList().ToList();
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(p => p.MessageId == id);

        }
        public List<Message> GetAllMessagesByStudentId(int studentId)
        {

            return _messageDal.GetList().Where(p => p.ReciverId == studentId).ToList();
        }

        public void Update(int MessageId,
                         int SenderId,
                         int ReciverId,
                         String? MessageContent = null,
                         DateTime? CreatedAt = null,
                         DateTime? UpdatedAt = null)
        {
            var messageToUpdate = _messageDal.Get(m => m.MessageId == MessageId);


            messageToUpdate.SenderId = SenderId;

            messageToUpdate.ReciverId = ReciverId;
            if (MessageContent != null)
                messageToUpdate.MessageContent = MessageContent;
            if (CreatedAt != null)
                messageToUpdate.CreatedAt = CreatedAt.Value;
            if (UpdatedAt != null)
                messageToUpdate.UpdatedAt = UpdatedAt.Value;

            _messageDal.Update(messageToUpdate);
        }
    }
}
