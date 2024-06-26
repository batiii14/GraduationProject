﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUniversityService
    {
        void Add(University university);
        void Delete(int id);
        void Update(int id,
                     string name = null,
                     string address = null,
                     DateTime? createdAt = null,
                     DateTime? updatedAt = null);
        List<University> GetAll();
        University GetById(int id);

        University GetUniversityByName(string name);
    }
}
