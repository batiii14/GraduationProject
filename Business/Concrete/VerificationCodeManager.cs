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
            throw new NotImplementedException();
        }

        public List<VerificationCode> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<VerificationCode> GetAllByStudentId(int id)
        {
            throw new NotImplementedException();
        }

        public Admin GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(VerificationCode verificationCode)
        {
            throw new NotImplementedException();
        }
    }
}
