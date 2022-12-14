
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface ITitleService
    {
        List<Title> GetList();
        List<Title> GetListPassive();
        void TitletAdd(Title title);
        Title GetByID(int id);
        void TitleDelete(Title title);
        void TitleUpdate(Title title);
    }
}
