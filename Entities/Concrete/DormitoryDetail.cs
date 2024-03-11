using Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    public class DormitoryDetail : IEntity
    {
        [Key]
        public int DetailId { get; set; }
        [ForeignKey("Dormitory")]
        public int DormitoryId { get; set; }
        public String ContactNo { get; set; }
        public String Email { get; set; }
        public String FaxNo { get; set; }
        public String Address { get; set; }
        public int Capacity { get; set; }
        public String Description { get; set; }
        public String InternetSpeed { get; set; }
        public Boolean HasKitchen { get; set; }
        public Boolean HasCleanService { get; set; }
        public Boolean HasShowerAndToilet { get; set; }
        public Boolean HasBalcony { get; set; }
        public Boolean HasTv { get; set; }
        public Boolean HasMicrowave { get; set; }
        public Boolean HasAirConditioning { get; set; }

        [NotMapped]
        public List<String> PhotoUrls { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
