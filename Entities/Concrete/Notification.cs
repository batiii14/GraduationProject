using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Notification : IEntity
    {
        public int NotificationId { get; set; }
        public String Title { get; set; }
        public string Description { get; set; }
        public String ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int RecieverId { get; set; }
        public int SenderId { get; set; }
        public Boolean Seen { get; set; }
    }
}
