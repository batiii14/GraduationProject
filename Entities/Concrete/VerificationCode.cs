using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class VerificationCode:IEntity
    {
        public int VerificationCodeId { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public String VerificationCodeForStudent { get; set; }
    }
}
