using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDormitoryDetailService
    {
        void Add(DormitoryDetail dormitoryDetail);
        void Delete(int id);
        void Update(DormitoryDetail dormitoryDetail);
        List<DormitoryDetail> GetAll();
        DormitoryDetail GetById(int id);
    }
}
