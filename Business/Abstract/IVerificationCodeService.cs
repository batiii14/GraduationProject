using Entities.Concrete;

namespace Business.Abstract
{
    public interface IVerificationCodeService
    {
        void Add(VerificationCode verificationCode);
        void Delete(int id);
        void Update(VerificationCode verificationCode);
        List<VerificationCode> GetAll();
        List<VerificationCode> GetAllByStudentId(int id);
        VerificationCode GetById(int id);
        Boolean verifyUser(VerificationCode verificationCode);
    }
}
