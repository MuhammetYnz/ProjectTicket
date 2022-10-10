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
    public class AdminDeliverController : Controller
    {
        // GET: AdminDeliver
        DeliverManager dm = new DeliverManager(new EfDeliverDal());
        UserManager um = new UserManager(new EfUserDal());
        Context context = new Context();
        public ActionResult AdminDeliverIndex()
        {
            var deliverValues = dm.GetList();
            return View(deliverValues);
        }

        [HttpGet]
        public ActionResult AddDeliver()
        {
            List<SelectListItem> valueUserName = (from x in um.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.UserName +" "+ x.UserLanstName,                                                  
                                                      Value = x.UserID.ToString()
                                                  }).ToList();
            ViewBag.vUsrName = valueUserName;

            return View();
        }

        [HttpPost]
        public ActionResult AddDeliver(Deliver p)
        {
           
            p.DeliverStatus = Status.Aktif;
            dm.DelivertAdd(p);
            return RedirectToAction("AdminDeliverIndex");
        }

        [HttpGet]
        public ActionResult EditDeliver(int id)
        {
            
            var delValue = dm.GetByID(id);
            return View(delValue);

        }

        [HttpPost]
        public ActionResult EditDeliver(Deliver p)
        {
            dm.DeliverUpdate(p);
            return RedirectToAction("AdminDeliverIndex");

        }
    }
}