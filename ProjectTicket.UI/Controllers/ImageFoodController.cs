using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectTicket.UI.Controllers
{
    public class ImageFoodController : Controller
    {
        ImageFileManager ım = new ImageFileManager(new EfImageFileDal());
        // GET: ImageFood
        public ActionResult IndexFood()
        {
            var ımageValue = ım.GetList();
            return View(ımageValue);
        }
    }
}