using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ProjectTicket.UI.Controllers
{
    public class AdminImageController : Controller
    {
        ImageFileManager ım = new ImageFileManager(new EfImageFileDal());
        // GET: Image
        public ActionResult FoodIndex()
        {
            var ımageValue = ım.GetList();
            return View(ımageValue);
        }

        [HttpGet]
        public ActionResult AddImageFood()
        {           
            return View();
        }

        [HttpPost]
        public ActionResult AddImageFood(ImageFile p, HttpPostedFileBase foodImage)
        {
            if (foodImage != null)
            {
                WebImage img = new WebImage(foodImage.InputStream);
                FileInfo imgInfo = new FileInfo(foodImage.FileName);

                string imgName = Guid.NewGuid().ToString() + imgInfo.Extension;
                img.Save("~/Uploads/FoodImage/" + imgName);
                p.ImagePath = "/Uploads/FoodImage/" + imgName;
            }
            ım.ImageFileAdd(p);
            return RedirectToAction("FoodIndex");
        }

        [HttpGet]
        public ActionResult EditImageFood(int id)
        {
            var ımageValue = ım.GetByID(id);
            return View(ımageValue);
        }

        [HttpPost]
        public ActionResult EditImageFood(int id,ImageFile p, HttpPostedFileBase foodImage)
        {
            if (ModelState.IsValid)
            {
                var foodImageValue = ım.GetByID(id);
                if (foodImage != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(foodImageValue.ImagePath)))
                    {
                        System.IO.File.Delete(Server.MapPath(foodImageValue.ImagePath));
                    }
                    WebImage img = new WebImage(foodImage.InputStream);
                    FileInfo imgInfo = new FileInfo(foodImage.FileName);

                    string foodImageName = Guid.NewGuid().ToString() + imgInfo.Extension;
                    img.Save("~/Uploads/FoodImage/" + foodImageName);

                    foodImageValue.ImagePath = "/Uploads/FoodImage/" + foodImageName;
                }
                foodImageValue.ImageName = p.ImageName;

                ım.ImageFileUpdate(foodImageValue);
                return RedirectToAction("FoodIndex");
            }
            return View(p);
        }
    }
}