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
    public class AdminUserController : Controller
    {
        UserManager um = new UserManager(new EfUserDal());
        DepartmentManager dm = new DepartmentManager(new EfDepartmentDal());
        TitleManager tm = new TitleManager(new EfTitleDal());
        Context c = new Context();

        // GET: AdminUser
       
        public ActionResult AdminUserIndex()
        {
            var userValues = um.GetList();
            return View(userValues);
        }

        [HttpGet]
        public ActionResult EditUser(int id)
        {
            var userValues = um.GetByID(id);
            List<SelectListItem> valueDepartment = (from x in dm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.DepartmentName,
                                                      Value = x.DepartmentID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueDepartment;

            List<SelectListItem> valueTitle = (from x in tm.GetList()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.TitleName,
                                                        Value = x.TitleID.ToString()
                                                    }).ToList();
            ViewBag.t = valueTitle;
            return View(userValues);
        }

        [HttpPost]
        public ActionResult EditUser(User p)
        {
            um.UserUpdate(p);
            return RedirectToAction("AdminUserIndex");
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            //var userValues = um.GetByID(id);
            List<SelectListItem> valueDepartment = (from x in dm.GetList()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.DepartmentName,
                                                        Value = x.DepartmentID.ToString()
                                                    }).ToList();
            ViewBag.vlc = valueDepartment;

            List<SelectListItem> valueTitle = (from x in tm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.TitleName,
                                                   Value = x.TitleID.ToString()
                                               }).ToList();
            ViewBag.t = valueTitle;
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(User p)
        {
            //string adminUserMailInfo = (string)Session["AdminMail"];
            //var adminUserIdInfo = c.Admins.Where(x => x.AdminMail == adminUserMailInfo).Select(y => y.AdminID).FirstOrDefault();
            //p.UserID = adminUserIdInfo;
            p.UserStatus =Status.Aktif;
            um.UserAdd(p); 
            return RedirectToAction("AdminUserIndex");
        }
    }
}