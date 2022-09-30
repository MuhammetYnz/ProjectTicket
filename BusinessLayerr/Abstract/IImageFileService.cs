using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IImageFileService
    {
        List<ImageFile> GetList();
        void ImageFileDelete(ImageFile ımageFile);
        void ImageFileAdd(ImageFile ımageFile);
        void ImageFileUpdate(ImageFile ımageFile);
        ImageFile GetByID(int id);
    }
}
