using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Deliver
    {
        [Key]
        public int DeliverID { get; set; }
        public string Brand { get; set; }
        public string Modell { get; set; }
        public string SerialNumber { get; set; }
        public int Quantity { get; set; }
        public DateTime DeliverDate { get; set; }
        public Status DeliverStatus { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }

        //public int DepartmentID { get; set; }
        //public virtual Department Department { get; set; }

        //public int TitleID { get; set; }
        //public virtual Title Title { get; set; }

    }
}
