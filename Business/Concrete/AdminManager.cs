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
    public class AdminManager : IAdminService
    {
        private IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal=adminDal;
        }

        public void Add(Admin admin)
        {
            _adminDal.Add(admin);
        }

        public void Delete(int id)
        {
            var admin = _adminDal.Get(p => p.UserId == id);
            _adminDal.Delete(admin);
        }

        public List<Admin> GetAll()
        {
            return _adminDal.GetList().ToList();
        }

        public Admin GetById(int id)
        {
            var admin = _adminDal.Get(p => p.UserId == id);
            return admin;
        }

        public void Update(Admin admin)
        {
            throw new NotImplementedException();
        }
    }
}
