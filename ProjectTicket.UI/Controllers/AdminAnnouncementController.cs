using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectTicket.UI.Controllers
{
    public class AdminAnnouncementController : Controller
    {
        AnnouncementManager acm = new AnnouncementManager(new EfAnnouncementDal());
        CategoryManager ctm = new CategoryManager(new EfCategoryDal());
        // GET: AdminAnnouncement
       
        public ActionResult Index()
        {
            var acmValues = acm.GetList();
            return View(acmValues);
        }

        public ActionResult AdminAnnouncementDetail(int id)
        {
            var announValue = acm.GetByID(id);
            return View(announValue);
        }

        [HttpGet]
        public ActionResult AddAnnouncement()
        {
            List<SelectListItem> valueCategory = (from x in ctm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;
            return View();
        }

        [HttpPost]
        public ActionResult AddAnnouncement(Announcement p)
        {
            acm.AnnouncementAdd(p);
            return RedirectToAction("Index");
        }
    }
}