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
    public class RatingManager : IRatingService
    {
        private IRatingDal _ratingDal;

        public RatingManager(IRatingDal ratingDal)
        {
            _ratingDal = ratingDal;
        }
        public void Add(Rating rating)
        {
            _ratingDal.Add(rating);
        }

        public void Delete(int id)
        {
            var rating=_ratingDal.Get(p=>p.RatingId == id);
            _ratingDal.Delete(rating);
        }

        public List<Rating> GetAll()
        {
            return _ratingDal.GetList().ToList();
        }

        public Rating GetById(int id)
        {
            return _ratingDal.Get(p => p.RatingId == id);


        }

        public List<Rating> GetRatingByDormitoryId(int id)
        {
            return _ratingDal.GetList(p => p.DormitoryId == id).ToList();
        }


        public void Update(int ratingId,
                         int dormitoryId,
                         int userId,
                         int ratingNo,
                         DateTime? createdAt = null,
                         DateTime? updatedAt = null)
        {
            var ratingToUpdate = _ratingDal.Get(p => p.RatingId == ratingId);

            if (dormitoryId != null)
                ratingToUpdate.DormitoryId = dormitoryId;
            if (userId != null)
                ratingToUpdate.UserId = userId;
            if (ratingNo != null)
                ratingToUpdate.RatingNo = ratingNo;
            if (createdAt != null)
                ratingToUpdate.CreatedAt = createdAt.Value;
            if (updatedAt != null)
                ratingToUpdate.UpdatedAt = updatedAt.Value;

            _ratingDal.Update(ratingToUpdate);
        }
    }
}
