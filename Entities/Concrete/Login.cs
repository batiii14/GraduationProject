using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Login : IEntity
    {
        public int UserName { get; set; }
        public string Password { get; set; }
    }
}
