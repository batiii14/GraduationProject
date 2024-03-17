using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRatingService
    {
        void Add(Rating rating);
        void Delete(int id);
        void Update(int ratingId, int dormitoryId, int userId,int ratingNo, DateTime? createdAt, DateTime? updatedAt);
        List<Rating> GetAll();
        Rating GetById(int id);
    }
}
