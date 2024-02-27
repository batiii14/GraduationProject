using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUniversityService
    {
        void Add(University university);
        void Delete(int id);
        void Update(University university);
        List<University> GetAll();
        University GetById(int id);
    }
}
