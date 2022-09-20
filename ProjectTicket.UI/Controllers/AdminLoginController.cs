using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjectTicket.UI.Controllers
{
    public class AdminLoginController : Controller
    {
        AdminManager adm = new AdminManager(new EfAdminDal());
        // GET: AdminLogin
       
        [HttpGet]
        public ActionResult AdminIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminIndex(Admin p)
        {
            var adminInfo = adm.GetAdmin(p.AdminMail, p.AdminPassword);
            if (adminInfo!=null)
            {
                FormsAuthentication.SetAuthCookie(adminInfo.AdminMail, false);
                Session["AdminMail"] = adminInfo.AdminMail;
                return RedirectToAction("Index", "AdminHome");
            }
            else
            {
                ViewBag.Error = "Hatalı Kullanıcı veya Şifre !!!";
                return View();
            }
            
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AdminIndex", "AdminLogin");
        }
    }
}