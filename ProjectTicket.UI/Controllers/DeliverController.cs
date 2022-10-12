using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectTicket.UI.Controllers
{
    public class DeliverController : Controller
    {
        Context c = new Context();
        DeliverManager dm = new DeliverManager(new EfDeliverDal());
        // GET: Deliver
        public ActionResult DeliverIndex(string p)
        {
            p = (string)Session["UserMail"];
            var userIdIinfo = c.Users.Where(x => x.UserMail == p).Select(y => y.UserID).FirstOrDefault();
            //ViewBag.d = p;
            var deliverValues = dm.GetListByUser(userIdIinfo).OrderByDescending(x => x.DeliverDate).ToList();
            
           
            return View(deliverValues);
        }

        public ActionResult AdminDeliverDetail(int id)
        {

            var delValue = dm.GetByID(id);
            return View(delValue);

            //Kullanıcı ya ad soyad ile hitap etmek için
            //var username = User.Identity.Name;
            //var userName = c.Users.Where(x => x.UserMail == username).Select(y => y.UserName).FirstOrDefault();
            //var userLastName = c.Users.Where(x => x.UserMail == username).Select(y => y.UserLanstName).FirstOrDefault();
            ////var userDOSName = c.Users.Where(x => x.UserMail == username).Select(y => y.UserDateOfStart).FirstOrDefault();

            //ViewBag.n = userName;
            //ViewBag.ln = userLastName;
            ////ViewBag.dos = userDOSName;
            
        }
    }
}