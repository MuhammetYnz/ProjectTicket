using BusinessLayer.Abstract;
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
            var extenValues = um.GetList();
            return View(extenValues);
        }
    }
}