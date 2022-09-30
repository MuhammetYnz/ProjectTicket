using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ImageFileManager : IImageFileService
    {
        IImageFıleDal _ımageFıleDal;

        public ImageFileManager(IImageFıleDal ımageFıleDal)
        {
            _ımageFıleDal = ımageFıleDal;
        }

        public ImageFile GetByID(int id)
        {
            return _ımageFıleDal.Get(x => x.ImageID == id);
        }

        public List<ImageFile> GetList()
        {
            return _ımageFıleDal.List();
        }

        public void ImageFileAdd(ImageFile ımageFile)
        {
            _ımageFıleDal.Insert(ımageFile);
        }

        public void ImageFileDelete(ImageFile ımageFile)
        {
            _ımageFıleDal.Delete(ımageFile);
        }

        public void ImageFileUpdate(ImageFile ımageFile)
        {
            _ımageFıleDal.Update(ımageFile);
        }
    }
}
