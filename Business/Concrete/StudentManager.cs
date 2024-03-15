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
    public class StudentManager : IStudentService
    {
        private IStudentDal _studentDal;

        public StudentManager(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }
        public void Add(Student student)
        {
            _studentDal.Add(student);
        }

        public void Delete(int id)
        {
            var student=_studentDal.Get(p=>p.UserId == id);
            _studentDal.Delete(student);
        }

        public List<Student> GetAll()
        {
            return _studentDal.GetList().ToList();
        }

        public Student GetById(int id)
        {
            return _studentDal.Get(p => p.UserId == id);

        }

        public void Update(int userId,
                   string studentNumber = null,
                   string department = null,
                   string gender = null,
                   string emergencyContactNo = null,
                   string name = null,
                   string surName = null,
                   string email = null,
                   string password = null,
                   string address = null,
                   string phoneNo = null,
                   DateTime? dob = null,
                   DateTime? createdAt = null,
                   DateTime? updatedAt = null,
                   string profileUrl = null)
        {
            var studentToUpdate = _studentDal.Get(p=>p.UserId==userId);

            if (studentToUpdate == null)
            {
                throw new Exception("Student not found"); // Handle the case where student is not found
            }

            // Update only the properties that are provided
            if (studentNumber != null)
                studentToUpdate.StudentNumber = studentNumber;
            if (department != null)
                studentToUpdate.Department = department;
            if (gender != null)
                studentToUpdate.Gender = gender;
            if (emergencyContactNo != null)
                studentToUpdate.EmergencyContactNo = emergencyContactNo;
            if (name != null)
                studentToUpdate.Name = name;
            if (surName != null)
                studentToUpdate.SurName = surName;
            if (email != null)
                studentToUpdate.Email = email;
            if (password != null)
                studentToUpdate.Password = password;
            if (address != null)
                studentToUpdate.Address = address;
            if (phoneNo != null)
                studentToUpdate.PhoneNo = phoneNo;
            
            if (dob != null)
                studentToUpdate.Dob = dob.Value;
            if (createdAt != null)
                studentToUpdate.CreatedAt = createdAt.Value;
            if (updatedAt != null)
                studentToUpdate.UpdatedAt = updatedAt.Value;
            if (profileUrl != null)
                studentToUpdate.ProfileUrl = profileUrl;

            _studentDal.Update(studentToUpdate);
        }


        public Student GetStudentByName(string name)
        {
            var student=_studentDal.Get(p=>p.Name.ToLower() == name.ToLower());

            return student;
        }

    }
}
