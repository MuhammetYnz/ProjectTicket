using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Concrete
{
   public class Content
    {
        [Key]
        public int ContentID { get; set; }
        public string ContentValue { get; set; }
        public DateTime ContentDate { get; set; }
        public Status ContentStatus { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }


        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
