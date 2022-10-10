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
    public class AdminDepartmentController : Controller
    {
        DepartmentManager dm = new DepartmentManager(new EfDepartmentDal());
        // GET: AdminDepartment
        
        public ActionResult DepartmentIndex()
        {
            var dmValues = dm.GetList();
            return View(dmValues);
        }

        [HttpGet]
        public ActionResult AddDepartment()
        {          
            return View();
        }

        [HttpPost]
        public ActionResult AddDepartment(Department p)
        {
            p.DepartmentStatus = Status.Aktif;
            dm.DepartmentAdd(p);
            return RedirectToAction("DepartmentIndex");
        }

        public ActionResult DepartmentActive(int id)
        {
            var dpValue = dm.GetByID(id);
            dpValue.DepartmentStatus = Status.Aktif;
            dm.DepartmentUpdate(dpValue);
            return RedirectToAction("paIndex","AdminPassiveActive");
        }
    }
}