using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILoginService
    {
        LoginResult Login(string email, string password);
    }

    public class LoginResult
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public IEntity User { get; set; }
    }
}
