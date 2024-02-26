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
            throw new NotImplementedException();
        }

        public List<Admin> GetAll()
        {
            throw new NotImplementedException();
        }

        public Admin GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Admin admin)
        {
            throw new NotImplementedException();
        }
    }
}
