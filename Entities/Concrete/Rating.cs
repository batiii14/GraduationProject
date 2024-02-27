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
    public class Rating : IEntity
    {
        [Key] 
        public int RatingId { get; set; }
        [ForeignKey("Dormitory")]
        public int DormitoryId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
    }
}
