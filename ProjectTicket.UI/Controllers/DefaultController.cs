using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectTicket.UI.Controllers
{
    public class DefaultController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        // GET: Default
        
        public ActionResult Index()
        {
            
            var contentList = cm.GetList();
            return View(contentList);
        }
    }
}