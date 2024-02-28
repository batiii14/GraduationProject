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

        public void Update(Rating rating)
        {
            throw new NotImplementedException();
        }
    }
}
