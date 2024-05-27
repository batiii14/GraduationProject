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

        public Comment GetCommentByDormitoryId(int id)
        {
            return _commentDal.Get(p => p.DormitoryId == id);
        }

        public List<Comment> GetAllCommentsByDormitoryId(int dormId)
        {
            ICommentDal commentDal = new CommentDal();
            var commentList= _commentDal.GetList().Where(p => p.DormitoryId == dormId).ToList();
            return commentList;
        }

        public void Update(int CommentId,
                           int DormitoryId,
                           String CommentContent,
                           int UserId,
                           DateTime CreatedAt,
                           DateTime UpdatedAt)
        {
            var commentToUpdate = _commentDal.Get(c => c.CommentId == CommentId);

            if (DormitoryId != null)
                commentToUpdate.DormitoryId = DormitoryId;
            if (CommentContent != null)
                commentToUpdate.CommentContent = CommentContent;
            if (UserId != null)
                commentToUpdate.UserId = UserId;
            if (CreatedAt != null)
                commentToUpdate.CreatedAt = CreatedAt;
            if (UpdatedAt != null)
                commentToUpdate.UpdatedAt = UpdatedAt;

            _commentDal.Update(commentToUpdate);
        }
    }
}
