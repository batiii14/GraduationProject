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

        public LoginResult Login(string email, string password)
        {
            var admins = _adminDal.GetList().ToList();
            var dormOwners = _dormitoryOwnerDal.GetList().ToList();
            var students = _studentDal.GetList().ToList();
            password = PasswordHasher.HashPassword(password);
            IEntity userToLogin = null;

            foreach (var item in students)
            {
                if (item.Email == email && item.Password == password)
                {
                    userToLogin = item;
                    break; // User found, exit loop
                }
            }

            if (userToLogin == null) // If user not found, check other lists
            {
                foreach (var item in admins)
                {
                    if (item.Email == email && item.Password == password)
                    {
                        userToLogin = item;
                        break;
                    }
                }

                foreach (var item in dormOwners)
                {
                    if (item.Email == email && item.Password == password)
                    {
                        userToLogin = item;
                        break;
                    }
                }
            }

            if (userToLogin == null)
            {
                return new LoginResult { IsSuccessful = false, Message = "User not found" };
            }

            return new LoginResult { IsSuccessful = true, User = userToLogin };
        }
    }
}
