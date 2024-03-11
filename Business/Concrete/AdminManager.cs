using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
            var hashedPassword=PasswordHasher.HashPassword(admin.Password);
            admin.Password=hashedPassword;
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

        public void Update(int UserId,
                       String Name,
                       String Email,
                       String Password,
                       String Address,
                       String PhoneNo,
                       DateTime CreatedAt,
                       DateTime UpdatedAt,
                       DateTime Dob,
                       String ProfileUrl)
        {
            var adminToUpdate = _adminDal.Get(u => u.UserId == UserId);

            if (Name != null)
                adminToUpdate.Name = Name;
            if (Email != null)
                adminToUpdate.Email = Email;
            if (Password != null)
                adminToUpdate.Password = Password;
            if (Address != null)
                adminToUpdate.Address = Address;
            if (PhoneNo != null)
                adminToUpdate.PhoneNo = PhoneNo;
            if (CreatedAt != null)
                adminToUpdate.CreatedAt = CreatedAt;
            if (UpdatedAt != null)
                adminToUpdate.UpdatedAt = UpdatedAt;
            if (Dob != null)
                adminToUpdate.Dob = Dob;
            if (ProfileUrl != null)
                adminToUpdate.ProfileUrl = ProfileUrl;

            _adminDal.Update(adminToUpdate);
        }

    }
}
