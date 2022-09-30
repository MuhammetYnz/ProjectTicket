using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
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
    [AllowAnonymous]
    public class UserLoginController : Controller
    {
        UserManager um = new UserManager(new EfUserDal());
        Context c = new Context();
        // GET: UserLogin
        
        [HttpGet]
        public ActionResult UserIndex()
        {

            return View();
        }

        [HttpPost]
        public ActionResult UserIndex(User p)
        {
            var userInfo = um.GetUser(p.UserMail, p.UserPassword);
            if (userInfo != null)
            {
                FormsAuthentication.SetAuthCookie(userInfo.UserMail, false);
                Session["UserMail"] = userInfo.UserMail;
                return RedirectToAction("Index", "Default");
            }
            else
            {
                ViewBag.Error = "Hatalı Kullanıcı veya Şifre !!!";
                return View();
            }

        }      

        public PartialViewResult UserLoginPartial()
        {
            var username = User.Identity.Name;
            var userName = c.Users.Where(x => x.UserMail == username).Select(y => y.UserName).FirstOrDefault();
            var userLastName = c.Users.Where(x => x.UserMail == username).Select(y => y.UserLanstName).FirstOrDefault();
            var userImage = c.Users.Where(x => x.UserMail == username).Select(y => y.UserImage).FirstOrDefault();
            ViewBag.n = userName;
            ViewBag.ln = userLastName;
            ViewBag.Imge = userImage;
            return PartialView();         
        }

    public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("UserIndex", "UserLogin");
        }
    }
}