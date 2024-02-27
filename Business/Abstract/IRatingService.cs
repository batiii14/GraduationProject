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
        void Update(Rating rating);
        List<Rating> GetAll();
        Rating GetById(int id);
    }
}
