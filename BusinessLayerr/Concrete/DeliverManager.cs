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
   public class DeliverManager:IDeliverService
    {
        IDeliverDal _deliverDal;

        public DeliverManager(IDeliverDal deliverDal)
        {
            _deliverDal = deliverDal;
        }

        public void DeliverDelete(Deliver deliver)
        {
            _deliverDal.Delete(deliver);
        }

        public void DelivertAdd(Deliver deliver)
        {
            _deliverDal.Insert(deliver);
        }

        public void DeliverUpdate(Deliver deliver)
        {
            _deliverDal.Update(deliver);
        }

        public Deliver GetByID(int id)
        {
            return _deliverDal.Get(x => x.DeliverID ==id);
        }

        public List<Deliver> GetList()
        {
            return _deliverDal.List();
        }

        public List<Deliver> GetListByUser(int id)
        {
            return _deliverDal.List(x => x.UserID == id);
        }
    }
}
