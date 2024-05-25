using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneMusic.EntityLayer.Entities
{
    public class UserNotifications
    {
        public int UserNotificationsID { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
