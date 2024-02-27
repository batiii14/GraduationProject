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
        void Update(Message message);
        List<Message> GetAll();
        Message GetById(int id);
    }
}
