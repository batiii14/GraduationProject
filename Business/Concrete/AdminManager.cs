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

        public void Update(int UserId, String Name = null, String SurName = null, String Email = null, String Password = null, String Address = null, String PhoneNo = null, DateTime? CreatedAt = null, DateTime? UpdatedAt = null, DateTime? Dob = null, String ProfileUrl = null)
        {
            var adminToUpdate = _adminDal.Get(u => u.UserId == UserId);

            if (Name != null)
                adminToUpdate.Name = Name;
            if (SurName != null)
                adminToUpdate.SurName = SurName;
            if (Email != null)
                adminToUpdate.Email = Email;
            if (Password != null)
                adminToUpdate.Password = PasswordHasher.HashPassword(Password);
            if (Address != null)
                adminToUpdate.Address = Address;
            if (PhoneNo != null)
                adminToUpdate.PhoneNo = PhoneNo;
            if (CreatedAt != null)
                adminToUpdate.CreatedAt = CreatedAt.Value;
            if (UpdatedAt != null)
                adminToUpdate.UpdatedAt = UpdatedAt.Value;
            if (Dob != null)
                adminToUpdate.Dob = Dob.Value;
            if (ProfileUrl != null)
                adminToUpdate.ProfileUrl = ProfileUrl;

            _adminDal.Update(adminToUpdate);
        }




        public Admin GetAdminByName(string AdminName)
        {
            var admin=_adminDal.Get(p=>p.Name.ToLower() == AdminName.ToLower());
            return admin;
        }

    }
}
