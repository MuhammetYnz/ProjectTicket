
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;

namespace DataAccessLayer.EntityFramework
{
   public class EfTitleDal: GenericRepository<Title>, ITitleDal
    {
    }
}
