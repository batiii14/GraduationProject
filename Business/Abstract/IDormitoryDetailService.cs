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
        void Update(int DetailId, int DormitoryId, String ContactNo, String Email, String FaxNo, String Address, int Capacity, String Description, String InternetSpeed, Boolean HasKitchen, Boolean HasCleanService, Boolean HasShowerAndToilet, Boolean HasBalcony, Boolean HasTv, Boolean HasMicrowave, Boolean HasAirConditioning, List<String> PhotoUrls, DateTime CreatedAt, DateTime UpdatedAt);
        List<DormitoryDetail> GetAll();
        DormitoryDetail GetById(int id);
        DormitoryDetail GetByDormitoryId(int id);
        void UpdatePhotoUrls(int detailId, List<string> photoUrls);
    }
}
