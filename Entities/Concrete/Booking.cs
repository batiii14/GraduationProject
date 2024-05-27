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
    public class Booking:IEntity
    {
        [Key]
        public int BookingId { get; set; }
        [ForeignKey("Student")]
        public int UserId { get; set; }
        [ForeignKey("Dormitory")]
        public int DormitoryId { get; set; }
        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public String Status { get; set; }
        public String PaymentStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime inMin { get; set; }
        public DateTime inMax { get; set; }
        public DateTime outMin { get; set; }
        public DateTime outMax { get; set; }
    }
}
