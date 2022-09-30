using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
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
        public ActionResult EditUser(int id,User p, HttpPostedFileBase userImage)
        {
            if (ModelState.IsValid)
            {
                var userImageValue = um.GetByID(id);
                if (userImage!=null)
                {
                    if (System.IO.File.Exists(Server.MapPath(userImageValue.UserImage)));
                    {
                        System.IO.File.Delete(Server.MapPath(userImageValue.UserImage));
                    }
                    WebImage img = new WebImage(userImage.InputStream);
                    FileInfo imgInfo = new FileInfo(userImage.FileName);

                    string userImageName = Guid.NewGuid().ToString() + imgInfo.Extension;
                    img.Save("~/Uploads/User/" + userImageName);

                    userImageValue.UserImage = "/Uploads/User/" + userImageName;
                }
                userImageValue.UserName = p.UserName;
                userImageValue.UserLanstName = p.UserLanstName;
                userImageValue.UserMail = p.UserMail;
                userImageValue.UserPassword = p.UserPassword;
                userImageValue.UserStatus = p.UserStatus;
                userImageValue.UserRole = p.UserRole;
                userImageValue.UserExtensionNumber = p.UserExtensionNumber;
                userImageValue.UserCompanyNumber = p.UserCompanyNumber;
                userImageValue.DepartmentID = p.DepartmentID;
                userImageValue.TitleID = p.TitleID;

                um.UserUpdate(userImageValue);
                return RedirectToAction("AdminUserIndex");
            }          
            return View(p);
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
        public ActionResult AddUser(User p, HttpPostedFileBase userImage)
        {
            //string adminUserMailInfo = (string)Session["AdminMail"];
            //var adminUserIdInfo = c.Admins.Where(x => x.AdminMail == adminUserMailInfo).Select(y => y.AdminID).FirstOrDefault();
            //p.UserID = adminUserIdInfo;
            p.UserStatus =Status.Aktif;           
            if (userImage!=null)
            {
                WebImage img = new WebImage(userImage.InputStream);
                FileInfo imgInfo = new FileInfo(userImage.FileName);

                string imgName = Guid.NewGuid().ToString() + imgInfo.Extension;
                img.Save("~/Uploads/User/" + imgName);
                p.UserImage = "/Uploads/User/" + imgName;
            }
            um.UserAdd(p); 
            return RedirectToAction("AdminUserIndex");
        }
    }
}