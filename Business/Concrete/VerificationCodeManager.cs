using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;

namespace Business.Concrete
{
    public class VerificationCodeManager : IVerificationCodeService
    {
        IVerificationCodeDal _verificationCodeDal;
        public VerificationCodeManager(IVerificationCodeDal verificationCodeDal)
        {
            _verificationCodeDal = verificationCodeDal;
        }
        public void Add(VerificationCode verificationCode)
        {
            _verificationCodeDal.Add(verificationCode);
        }

        public void Delete(int id)
        {
            var toDelete = _verificationCodeDal.Get(p => p.StudentId == id);
            _verificationCodeDal.Delete(toDelete);
        }

        public List<VerificationCode> GetAll()
        {
            return _verificationCodeDal.GetList().ToList();
        }

        public List<VerificationCode> GetAllByStudentId(int id)
        {
            var list = _verificationCodeDal.GetList().Where(p => p.StudentId == id).ToList();
            return list;
        }


        public VerificationCode GetById(int id)
        {
            var verificationCode = _verificationCodeDal.Get(p => p.StudentId == id);
            return verificationCode;
        }

        public void Update(VerificationCode verificationCode)
        {
            _verificationCodeDal.Update(verificationCode);
        }

        public Boolean verifyUser(VerificationCode verificationCode)
        {
            var isVerified = false;
            IStudentDal _studentDal = new StudentDal();

            var studentToUpdate = _studentDal.Get(p => p.UserId == verificationCode.StudentId);
            var verificationList = _verificationCodeDal.GetList();
            foreach (var vCode in verificationList)
            {
                if (vCode.StudentId == verificationCode.StudentId && vCode.VerificationCodeForStudent == verificationCode.VerificationCodeForStudent)
                {
                    studentToUpdate.isEmailVerified = true;
                    _studentDal.Update(studentToUpdate);
                    isVerified = true;
                }
            }

            return isVerified;
        }
    }
}