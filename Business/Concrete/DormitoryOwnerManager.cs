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
    public class DormitoryOwnerManager : IDormitoryOwnerService
    {

        private IDormitoryOwnerDal _dormitoryOwnerDal;

        public DormitoryOwnerManager(IDormitoryOwnerDal dormitoryOwnerDal)
        {
            _dormitoryOwnerDal = dormitoryOwnerDal;
        }
        public void Add(DormitoryOwner dormitoryOwner)
        {
            _dormitoryOwnerDal.Add(dormitoryOwner);
        }

        public void Delete(int id)
        {
            var dormOwner=_dormitoryOwnerDal.Get(p=>p.UserId == id);
            _dormitoryOwnerDal.Delete(dormOwner);
        }

        public List<DormitoryOwner> GetAll()
        {
            return _dormitoryOwnerDal.GetList().ToList();
        }

        public DormitoryOwner GetById(int id)
        {
            return _dormitoryOwnerDal.Get(p=>p.UserId == id);

        }

        public void Update(DormitoryOwner dormitoryOwner)
        {
            throw new NotImplementedException();
        }

        public DormitoryOwner GetDormitoryOwnerByName(string name)
        {
            var dormitoryOwner = _dormitoryOwnerDal.Get(p => p.Name.ToLower() == name.ToLower());

            return dormitoryOwner;
        }
    }
}
