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
    public class AdminTitleController : Controller
    {
        TitleManager tm = new TitleManager(new EfTitleDal());
        // GET: AdminTitle
        public ActionResult TitleIndex()
        {
            var titleValue = tm.GetList();
            return View(titleValue);
        }

        [HttpGet]
        public ActionResult AddTitle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTitle(Title p)
        {
            tm.TitletAdd(p);
            return RedirectToAction("TitleIndex");
        }

        [HttpGet]
        public ActionResult EditTitle(int id)
        {
            var titletValue = tm.GetByID(id);
            return View(titletValue);
        }

        [HttpPost]
        public ActionResult EditTitle(Title p)
        {
            tm.TitleUpdate(p);
            return RedirectToAction("TitleIndex");
        }

        public ActionResult TitleActive(int id)
        {
            var titValue = tm.GetByID(id);
            titValue.Status = Status.Aktif;
            tm.TitleUpdate(titValue);
            return RedirectToAction("paIndex", "AdminPassiveActive");
        }
    }
}