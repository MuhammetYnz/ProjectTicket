using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectTicket.UI.Controllers
{
    public class NewEmployeeController : Controller
    {
        UserManager um = new UserManager(new EfUserDal());
        // GET: NewEmployee
        
        public ActionResult Index()
        {
            var extenValues = um.GetList().OrderByDescending(x=>x.UserID).Take(6).ToList();
            return View(extenValues);          
        }
    }
}