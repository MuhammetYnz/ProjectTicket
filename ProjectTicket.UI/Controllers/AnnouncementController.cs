using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
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
          
            var acValues = acm.GetList().OrderByDescending(x=>x.AnnouncementDate).ToList();
            return View(acValues);
        }

        public ActionResult AnnouncementDetail(int id)
        {
            var announValue = acm.GetByID(id);
            return View(announValue);
        }
    }
}