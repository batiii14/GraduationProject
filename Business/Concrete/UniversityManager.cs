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
            var universityToDelete = _universityDal.Get(p => p.UniversityId == id);
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

        public void Update(int id,
                     string name = null,
                     string address = null,
                     DateTime? createdAt = null,
                     DateTime? updatedAt = null)
        {
            var universityToUpdate = _universityDal.Get(p => p.UniversityId == id);

            if (name != null)
                universityToUpdate.Name = name;
            if (address != null)
                universityToUpdate.Address = address;
            if (createdAt != null)
                universityToUpdate.CreatedAt = createdAt.Value;
            if (updatedAt != null)
                universityToUpdate.UpdatedAt = updatedAt.Value;

            _universityDal.Update(universityToUpdate);
        }


        public University GetUniversityByName(string name)
        {
             var university=_universityDal.Get(p=>p.Name.ToLower() == name.ToLower());

            return university;
        }

    }
}