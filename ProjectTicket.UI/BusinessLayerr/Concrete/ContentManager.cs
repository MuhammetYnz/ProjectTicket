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
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void ContentAdd(Content content)
        {
            _contentDal.Insert(content);
        }

        public void ContentDelete(Content content)
        {
            throw new NotImplementedException();
        }

        public void ContentUpdate(Content content)
        {
            _contentDal.Update(content);
        }

        public Content GetByID(int id)
        {
            return _contentDal.Get(x => x.ContentID == id);
        }

        public List<Content> GetList(/*string p*/)
        {
            //return _contentDal.List(x => x.ContentValue.Contains(p));
            return _contentDal.List();
        }

        public List<Content> GetListByUser(int id)
        {
            return _contentDal.List(x => x.UserID == id);
        }
    }
}
