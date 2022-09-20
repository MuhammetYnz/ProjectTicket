
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
   public class TitleManager: ITitleService
    {
        ITitleDal _title;

        public TitleManager(ITitleDal title)
        {
            _title = title;
        }

        public Title GetByID(int id)
        {
            return _title.Get(x => x.TitleID == id);
        }

        public List<Title> GetList()
        {
            return _title.List();
        }

        public void TitleDelete(Title title)
        {
            throw new NotImplementedException();
        }

        public void TitletAdd(Title title)
        {
            _title.Insert(title);
        }

        public void TitleUpdate(Title title)
        {
            _title.Update(title);
        }
    }
}
