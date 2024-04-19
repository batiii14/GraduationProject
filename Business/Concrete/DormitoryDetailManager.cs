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

        public DormitoryDetail GetByDormitoryId(int id)
        {
            return _dormitoryDetailDal.Get(p => p.DormitoryId == id);
        }

        public void Update(int DetailId,
                                  int DormitoryId,
                                  String ContactNo,
                                  String Email,
                                  String FaxNo,
                                  String Address,
                                  int Capacity,
                                  String Description,
                                  String InternetSpeed,
                                  bool HasKitchen,
                                  bool HasCleanService,
                                  bool HasShowerAndToilet,
                                  bool HasBalcony,
                                  bool HasTv,
                                  bool HasMicrowave,
                                  bool HasAirConditioning,
                                  List<String> PhotoUrls,
                                  DateTime CreatedAt,
                                  DateTime UpdatedAt)
        {
            var dormitoryDetailsToUpdate = _dormitoryDetailDal.Get(d => d.DetailId == DetailId);

            if (DormitoryId != null)
                dormitoryDetailsToUpdate.DormitoryId = DormitoryId;
            if (ContactNo != null)
                dormitoryDetailsToUpdate.ContactNo = ContactNo;
            if (Email != null)
                dormitoryDetailsToUpdate.Email = Email;
            if (FaxNo != null)
                dormitoryDetailsToUpdate.FaxNo = FaxNo;
            if (Address != null)
                dormitoryDetailsToUpdate.Address = Address;
            if (Capacity != null)
                dormitoryDetailsToUpdate.Capacity = Capacity;
            if (Description != null)
                dormitoryDetailsToUpdate.Description = Description;
            if (InternetSpeed != null)
                dormitoryDetailsToUpdate.InternetSpeed = InternetSpeed;

            dormitoryDetailsToUpdate.HasKitchen = HasKitchen;
            dormitoryDetailsToUpdate.HasCleanService = HasCleanService;
            dormitoryDetailsToUpdate.HasShowerAndToilet = HasShowerAndToilet;
            dormitoryDetailsToUpdate.HasBalcony = HasBalcony;
            dormitoryDetailsToUpdate.HasTv = HasTv;
            dormitoryDetailsToUpdate.HasMicrowave = HasMicrowave;
            dormitoryDetailsToUpdate.HasAirConditioning = HasAirConditioning;

            if (PhotoUrls != null)
                dormitoryDetailsToUpdate.PhotoUrls = PhotoUrls;
            if (CreatedAt != null)
                dormitoryDetailsToUpdate.CreatedAt = CreatedAt;
            if (UpdatedAt != null)
                dormitoryDetailsToUpdate.UpdatedAt = UpdatedAt;

            _dormitoryDetailDal.Update(dormitoryDetailsToUpdate);
        }

        public void UpdatePhotoUrls(int detailId, List<string> photoUrls)
        {
            var dormitoryDetailsToUpdate = _dormitoryDetailDal.Get(d => d.DetailId == detailId);
            if (photoUrls != null)
                dormitoryDetailsToUpdate.PhotoUrls = photoUrls;

            _dormitoryDetailDal.Update(dormitoryDetailsToUpdate);

        }
    }
}
