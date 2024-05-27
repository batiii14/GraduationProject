using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAdminService
    {
        void Add(Admin admin);
        void Delete(int id);
        void Update(int UserId, String Name, String SurName, String Email, String Password, String Address, String PhoneNo, DateTime? CreatedAt, DateTime? UpdatedAt, DateTime? Dob, String ProfileUrl);
        List<Admin> GetAll();
        Admin GetById(int id);
        Admin GetAdminByName(string AdminName);
    }
}
