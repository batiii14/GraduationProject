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

        public void Update(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
