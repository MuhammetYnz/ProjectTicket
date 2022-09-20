using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Concrete
{
   public class Announcement
    {
        [Key]
        public int AnnouncementID { get; set; }
        public string AnnouncementName { get; set; }
        public string AnnouncementContent { get; set; }
        public DateTime AnnouncementDate { get; set; }
        public Status AnnouncementStatus { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
