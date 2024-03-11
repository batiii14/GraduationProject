using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDormitoryOwnerService
    {
        void Add(DormitoryOwner dormitoryOwner);
        void Delete(int id);
        void Update(int UserId,int DormitoryId,String Name,String SurName,String Email,String Password, String Address,String PhoneNo,DateTime CreatedAt,DateTime UpdatedAt,DateTime Dob,String ProfileUrl);
        List<DormitoryOwner> GetAll();
        DormitoryOwner GetById(int id);
    }
}
