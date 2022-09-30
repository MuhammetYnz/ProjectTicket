using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
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
        public ActionResult AddAnnouncement(Announcement p, HttpPostedFileBase ancImage)
        {
            p.AnnouncementStatus = Status.Aktif;
            if (ancImage != null)
            {
                WebImage img = new WebImage(ancImage.InputStream);
                FileInfo imgInfo = new FileInfo(ancImage.FileName);

                string imgName = Guid.NewGuid().ToString() + imgInfo.Extension;
                img.Save("~/Uploads/Announcement/" + imgName);
                p.AnnouncementImage = "/Uploads/Announcement/" + imgName;
            }
            acm.AnnouncementAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAnnouncement(int id)
        {
            var ancValue = acm.GetByID(id);
            return View(ancValue);
        }

        [HttpPost]
        public ActionResult EditAnnouncement(int id,Announcement p, HttpPostedFileBase ancImage)
        {
            if (ModelState.IsValid)
            {
                var acmImageValue = acm.GetByID(id);
                if (ancImage != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(acmImageValue.AnnouncementImage))) ;
                    {
                        System.IO.File.Delete(Server.MapPath(acmImageValue.AnnouncementImage));
                    }
                    WebImage img = new WebImage(ancImage.InputStream);
                    FileInfo imgInfo = new FileInfo(ancImage.FileName);

                    string userImageName = Guid.NewGuid().ToString() + imgInfo.Extension;
                    img.Save("~/Uploads/User/" + userImageName);

                    acmImageValue.AnnouncementImage = "/Uploads/User/" + userImageName;
                }
                acmImageValue.AnnouncementName = p.AnnouncementName;
                acmImageValue.AnnouncementStatus = p.AnnouncementStatus;
                acmImageValue.CategoryID = p.CategoryID;
                acmImageValue.AnnouncementContent = p.AnnouncementContent;
                acmImageValue.AnnouncementDate = p.AnnouncementDate;

                acm.AnnouncementUpdate(acmImageValue);
                return RedirectToAction("Index");
            }
            return View(p);
        }
    }
}