using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStudentService
    {
        void Add(Student student);
        void Delete(int id);
        void Update(int userId,
                   string studentNumber,
                   string department,
                   string gender,
                   string emergencyContactNo,
                   string name,
                   string surName,
                   string email,
                   string password,
                   string address,
                   string phoneNo,

                   DateTime? dob,
                   DateTime? createdAt,
                   DateTime? updatedAt,
                   string profileUrl);
        List<Student> GetAll();
        Student GetById(int id);
        Student GetStudentByName(string name);
    }
}
