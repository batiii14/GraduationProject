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
    public class DormitoryManager : IDormitoryService
    {
        private IDormitoryDal _dormitoryDal;

        public DormitoryManager(IDormitoryDal dormitoryDal)
        {
            _dormitoryDal= dormitoryDal;
        }
        public void Add(Dormitory dormitory)
        {
            _dormitoryDal.Add(dormitory);
        }

        public void Delete(int id)
        {
            var dorm=_dormitoryDal.Get(p=>p.DormitoryId==id);
            _dormitoryDal.Delete(dorm);
        }

        public List<Dormitory> GetAll()
        {
            return _dormitoryDal.GetList().ToList();
        }

        public Dormitory GetById(int id)
        {
            return _dormitoryDal.Get(p=>p.DormitoryId==id);
            
        }

        public void Update(Dormitory dormitory)
        {
            throw new NotImplementedException();
        }
    }
}
