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
    public class AnnouncementManager : IAnnouncementService
    {
        IAnnouncementDal _announcementDal;

        public AnnouncementManager(IAnnouncementDal announcementDal)
        {
            _announcementDal = announcementDal;
        }

        public void AnnouncementAdd(Announcement announcement)
        {
            _announcementDal.Insert(announcement);
        }

        public void AnnouncementDelete(Announcement announcement)
        {
            throw new NotImplementedException();
        }

        public void AnnouncementUpdate(Announcement announcement)
        {
            _announcementDal.Update(announcement);
        }

        public Announcement GetByID(int id)
        {
            return _announcementDal.Get(x => x.AnnouncementID == id);
        }

        public List<Announcement> GetList()
        {
            return _announcementDal.List();
        }
    }

}
