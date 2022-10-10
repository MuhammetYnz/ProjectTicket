using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
   public class Title
    {
        [Key]
        public int TitleID { get; set; }
        public string TitleName { get; set; }       
        public Status Status { get; set; }

        public ICollection<User> Users { get; set; }
        //public ICollection<Deliver> Delivers { get; set; }

    }
}
