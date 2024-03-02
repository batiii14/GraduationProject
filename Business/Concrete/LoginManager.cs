using Business.Abstract;
using Core.Entities;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class LoginManager : ILoginService
    {
        IAdminDal _adminDal;
        IDormitoryOwnerDal _dormitoryOwnerDal;
        IStudentDal _studentDal;

        public LoginManager(IStudentDal studentDal, IDormitoryOwnerDal dormitoryOwnerDal, IAdminDal adminDal)
        {
            _adminDal = adminDal;
            _dormitoryOwnerDal = dormitoryOwnerDal;
            _studentDal = studentDal;
            
        }
        public IEntity Login(string username, string password)
        {
            var admins = _adminDal.GetList().ToList();
            var dormOwners = _dormitoryOwnerDal.GetList().ToList();
            var students = _studentDal.GetList().ToList();
             password = PasswordHasher.HashPassword(password);
            IEntity userToLogin = null;

            foreach (var item in students)
            {
                if (item.Name == username && item.Password == password)
                {
                    userToLogin = item;
                    break; // Kullanıcı bulunduğunda döngüden çık
                }
            }

            if (userToLogin == null) // Eğer kullanıcı henüz bulunmadıysa diğer listelere bak
            {
                foreach (var item in admins)
                {
                    if (item.Name == username && item.Password == password)
                    {
                        userToLogin = item;
                        break;
                    }
                }

                foreach (var item in dormOwners)
                {
                    if (item.Name == username && item.Password == password)
                    {
                        userToLogin = item;
                        break;
                    }
                }
            }

            if (userToLogin == null)
            {
                throw new Exception("Kullanıcı bulunamadı."); 
            }

            return userToLogin;
        }

    }
}
