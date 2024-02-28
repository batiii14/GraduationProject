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
    public class DormitoryDetailManager : IDormitoryDetailService
    {
        private IDormitoryDetailDal _dormitoryDetailDal;

        public DormitoryDetailManager(IDormitoryDetailDal dormitoryDetailDal)
        {
            _dormitoryDetailDal= dormitoryDetailDal;
        }
        public void Add(DormitoryDetail dormitoryDetail)
        {
            _dormitoryDetailDal.Add(dormitoryDetail);
        }

        public void Delete(int id)
        {
            var dormDetail=_dormitoryDetailDal.Get(p=>p.DetailId==id);
            _dormitoryDetailDal.Delete(dormDetail);
        }

        public List<DormitoryDetail> GetAll()
        {
            return _dormitoryDetailDal.GetList().ToList();
        }

        public DormitoryDetail GetById(int id)
        {
            return _dormitoryDetailDal.Get(p => p.DetailId == id);
        }

        public void Update(DormitoryDetail dormitoryDetail)
        {
            throw new NotImplementedException();
        }
    }
}
