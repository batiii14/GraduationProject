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
    public class Message : IEntity
    {
        [Key]
        public int MessageId { get; set; }
        [ForeignKey("Student")]
        public int SenderId { get; set; }
        [ForeignKey("Student")]
        public int ReciverId { get; set; }
        public String MessageContent { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
