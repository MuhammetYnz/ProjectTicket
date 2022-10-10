
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Concrete
{
   public class User
    {
        [Key]
        public int UserID { get; set; }       
        public string UserName { get; set; }        
        public string UserLanstName { get; set; }       
        public string UserMail { get; set; }       
        public string UserPassword { get; set; }        
        public Status UserStatus { get; set; }
        public Role UserRole { get; set; }        
        public string UserExtensionNumber { get; set; }       
        public string UserCompanyNumber { get; set; }
        //public string UserTitle { get; set; }
        public string UserImage { get; set; }
        public DateTime UserDateOfStart { get; set; }

        public ICollection<Content> Contents { get; set; }
        public ICollection<Deliver> Delivers { get; set; }

        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }

        public int TitleID { get; set; }
        public virtual Title Title { get; set; }

    }
}
