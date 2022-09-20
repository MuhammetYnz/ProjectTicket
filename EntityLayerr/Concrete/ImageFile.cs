using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Concrete
{
   public class ImageFile
    {
        [Key]
        public int ImageID { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
    }
}
