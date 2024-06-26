﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Admin:IEntity
    {
        [Key]
        public int UserId { get; set; }
        public String UserType { get; set; }
        public String Name { get; set; }
        public String SurName { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String Address { get; set; }
        public String PhoneNo { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime Dob { get; set; }
        public String ProfileUrl { get; set; }
        
    }
}
