using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDormitoryService
    {
        void Add(Dormitory dormitory);
        void Delete(int id);
        void Update(Dormitory dormitory);
        List<Dormitory> GetAll();
        Dormitory GetById(int id);
    }
}
