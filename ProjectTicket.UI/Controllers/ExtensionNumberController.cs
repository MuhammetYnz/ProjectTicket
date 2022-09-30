using BusinessLayer.Abstract;
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
    public class ExtensionNumberController : Controller
    {
        UserManager um = new UserManager(new EfUserDal());      
        // GET: ExtensionNumber
        
        public ActionResult Index()
        {
            var user = um.GetList();
            return View(user);

        }     
    }
}