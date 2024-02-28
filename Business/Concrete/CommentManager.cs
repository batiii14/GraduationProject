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
    public class CommentManager : ICommentService
    {
        private ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal= commentDal;
        }
        public void Add(Comment comment)
        {
            _commentDal.Add(comment);
        }

        public void Delete(int id)
        {
            var commentToDelete=_commentDal.Get(p=>p.CommentId==id);
            _commentDal.Delete(commentToDelete);
        }

        public List<Comment> GetAll()
        {
            return _commentDal.GetList().ToList();
        }

        public Comment GetById(int id)
        {
            return  _commentDal.Get(p => p.CommentId == id);
        }

        public void Update(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
