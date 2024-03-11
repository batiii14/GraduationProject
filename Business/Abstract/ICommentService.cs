using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICommentService
    {
        void Add(Comment comment);
        void Delete(int id);
        void Update(int CommentId,int DormitoryId,String CommentContent,int UserId,DateTime CreatedAt,DateTime UpdatedAt);
        List<Comment> GetAll();
        Comment GetById(int id);
    }
}
