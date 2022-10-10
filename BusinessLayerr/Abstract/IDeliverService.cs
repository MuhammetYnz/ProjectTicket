using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
  public interface IDeliverService
    {
        List<Deliver> GetList();
        List<Deliver> GetListByUser(int id);
        void DelivertAdd(Deliver deliver);
        void DeliverDelete(Deliver deliver);
        void DeliverUpdate(Deliver deliver);
        Deliver GetByID(int id);
    }
}
