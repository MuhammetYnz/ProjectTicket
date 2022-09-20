using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Concrete
{
   public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public Status CategoryStatus { get; set; }

        public ICollection<Content> Contents { get; set; }
        public ICollection<Announcement> Announcements { get; set; }

    }
}
