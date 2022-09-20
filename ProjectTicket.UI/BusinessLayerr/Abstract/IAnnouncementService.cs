using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IAnnouncementService
    {
        List<Announcement> GetList();
        void AnnouncementAdd(Announcement announcement);
        Announcement GetByID(int id);
        void AnnouncementDelete(Announcement announcement);
        void AnnouncementUpdate(Announcement announcement);
    }
}
