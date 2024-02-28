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
            var message=_messageDal.Get(p=>p.MessageId == id);
            _messageDal.Delete(message);
        }

        public List<Message> GetAll()
        {
            return _messageDal.GetList().ToList();
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(p=>p.MessageId == id);

        }

        public void Update(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
