using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Dormitory : IEntity
    {
        [Key]
        public int DormitoryId { get; set; }
        public String Name { get; set; }
        [ForeignKey("University")]
        public int UniversityId { get; set; }
        public int Quota { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
