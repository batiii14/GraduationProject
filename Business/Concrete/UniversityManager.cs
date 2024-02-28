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
    public class UniversityManager : IUniversityService
    {

        private IUniversityDal _universityDal;
        public UniversityManager(IUniversityDal universityDal)
        {
            _universityDal = universityDal;
        }
        public void Add(University university)
        {
            _universityDal.Add(university);
        }

        public void Delete(int id)
        {
            var universityToDelete=_universityDal.Get(p=>p.UniversityId == id);
            _universityDal.Delete(universityToDelete);
        }

        public List<University> GetAll()
        {
            return _universityDal.GetList().ToList();
        }

        public University GetById(int id)
        {
            return _universityDal.Get(p => p.UniversityId == id);

        }

        public void Update(University university)
        {
            throw new NotImplementedException();
        }
    }
}