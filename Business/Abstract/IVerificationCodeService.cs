using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IVerificationCodeService
    {
        void Add(VerificationCode verificationCode);
        void Delete(int id);
        void Update(VerificationCode verificationCode);
        List<VerificationCode> GetAll();
        List<VerificationCode> GetAllByStudentId(int id);
        Admin GetById(int id);
    }
}
