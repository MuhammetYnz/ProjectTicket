using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;


namespace ProjectTicket.UI.Controllers
{
    public class AdminContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        // GET: AdminContent
        
        public ActionResult Index(int p=1)
        {
            //um.GetList().OrderByDescending(x => x.UserID).Take(6).ToList();
            var values = cm.GetList().OrderByDescending(x=>x.ContentDate).ToList().ToPagedList(p,7);
            return View(values);
        }
        
        [HttpGet]
        public ActionResult EditContent(int id)
        {
            var contentValue = cm.GetByID(id);
            return View(contentValue);
        }
        
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditContent(Content p)
        {
            cm.ContentUpdate(p);
            return RedirectToAction("Index");
        }
    }
}