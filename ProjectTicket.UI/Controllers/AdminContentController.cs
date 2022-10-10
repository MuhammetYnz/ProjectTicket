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
    public class AdminContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        // GET: AdminContent
        
        public ActionResult Index()
        {
            //um.GetList().OrderByDescending(x => x.UserID).Take(6).ToList();
            var values = cm.GetList().OrderByDescending(x=>x.ContentDate).ToList();
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