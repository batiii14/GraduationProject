using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Business.Concrete
{
    public class EmailSenderManager : IEmailSenderService
    {
        IVerificationCodeDal _verificationCodeDal;

        public EmailSenderManager(IVerificationCodeDal verificationCodeDal)
        {
            _verificationCodeDal = verificationCodeDal;
        }
        public string GenerateVerificationCode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var code = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                code.Append(chars[random.Next(chars.Length)]);
            }

            return code.ToString();
        }

        public Task SendEmailAsync(string email, string subject, string message, int studentId)
        {
            var verificationCode = GenerateVerificationCode(6);
            VerificationCode verification = new VerificationCode();
            verification.StudentId = studentId;
            verification.VerificationCodeForStudent = verificationCode;
            _verificationCodeDal.Add(verification);
            var client = new SmtpClient("smtp.office365.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("graduationprojectteam@outlook.com", "deneme12345")
            };





            return client.SendMailAsync(
                new MailMessage(from: "graduationprojectteam@outlook.com",
                                to: email,
                                subject,
                                message + verificationCode
                                ));



        }

    }
}