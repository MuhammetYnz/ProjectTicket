using BusinessLayer.Abstract;
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
    public class ContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        CategoryManager ctm = new CategoryManager(new EfCategoryDal());

        Context c = new Context();
        // GET: Content
        
        public ActionResult ContentIndex(string p)
        {
            p = (string)Session["UserMail"];
            var userIdIinfo = c.Users.Where(x => x.UserMail == p).Select(y => y.UserID).FirstOrDefault();
            //ViewBag.d = p;
            var contentValues = cm.GetListByUser(userIdIinfo).OrderByDescending(x=>x.ContentDate).ToList();

            //Kullanıcı ya ad soyad ile hitap etmek için
            var username = User.Identity.Name;
            var userName = c.Users.Where(x => x.UserMail == username).Select(y => y.UserName).FirstOrDefault();
            var userLastName = c.Users.Where(x => x.UserMail == username).Select(y => y.UserLanstName).FirstOrDefault();

            ViewBag.n = userName;
            ViewBag.ln = userLastName;


            return View(contentValues);
        }

        [HttpGet]     
        public ActionResult AddContent()
        {
            List<SelectListItem> valueCategory = (from x in ctm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;
            //ViewBag.d = id;
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddContent(Content p)
        {
            string userMailInfo = (string)Session["UserMail"];
            var userIdInfo = c.Users.Where(x => x.UserMail == userMailInfo).Select(y => y.UserID).FirstOrDefault();
            p.ContentDate = DateTime.Parse(DateTime.Now.ToString("dd MMM yyyy hh:mm"));
            p.UserID = userIdInfo;
            p.ContentStatus = Status.İncelemede;
            cm.ContentAdd(p);
            return RedirectToAction("ContentIndex");
        }
    }
    
}