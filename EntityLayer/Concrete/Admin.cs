using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Concrete
{
   public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        public string AdminMail { get; set; }
        public string AdminPassword { get; set; }
    }
}
