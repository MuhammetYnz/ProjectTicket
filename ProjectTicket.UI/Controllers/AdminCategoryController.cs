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
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        Context c = new Context();
        // GET: AdminCategory
        
        public ActionResult Index()
        {
            var categoryValues = cm.GetList();
            return View(categoryValues);
        }
         [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            if (c.Categories.Any(x=>x.CategoryName==p.CategoryName)) return RedirectToAction("Index");// aynı kategori eklenmesin
            p.CategoryStatus = Status.Aktif;
            cm.CategoryAdd(p);
            return RedirectToAction("Index");
        }

        //public ActionResult DeleteCategory(int id)
        //{
        //    //var categoryValue = cm.GetByID(id);
        //    //cm.CategoryDelete(categoryValue);
        //    //return RedirectToAction("Index");
        //}

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryValue = cm.GetByID(id);
            return View(categoryValue);
        }

        [HttpPost]
        public ActionResult EditCategory(Category p)
        {
            cm.CategoryUpdate(p);
            return RedirectToAction("Index");
        }
    }
}