using BusinessLayer.Abstract;
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
    public class AdminPassiveActiveController : Controller
    {
        DepartmentManager dm = new DepartmentManager(new EfDepartmentDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        TitleManager tm = new TitleManager(new EfTitleDal());
        UserManager um = new UserManager(new EfUserDal());
        // GET: AdminPassiveActive
        public ActionResult paIndex()
        {
            return View();
        }

        public PartialViewResult DepartmentPassive()
        {
            var depValues = dm.GetListPassive();
            return PartialView(depValues);
            
        }

        public PartialViewResult CategoryPassive()
        {
            var catValues = cm.GetListPassive();
            return PartialView(catValues);

        }

        public PartialViewResult TitlePassive()
        {
            var titValues = tm.GetListPassive();
            return PartialView(titValues);

        }

        public ActionResult UserPassive()
        {
            var usrValues = um.GetListPassive();
            return PartialView(usrValues);
        }
    }
}