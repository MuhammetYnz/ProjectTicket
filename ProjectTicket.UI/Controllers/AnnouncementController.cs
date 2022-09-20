using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectTicket.UI.Controllers
{
    public class AnnouncementController : Controller
    {
        AnnouncementManager acm = new AnnouncementManager(new EfAnnouncementDal());
        // GET: Announcement
       
        public ActionResult Index()
        {
            var acValues = acm.GetList();
            return View(acValues);
        }

        public ActionResult AnnouncementDetail(int id)
        {
            var announValue = acm.GetByID(id);
            return View(announValue);
        }
    }
}