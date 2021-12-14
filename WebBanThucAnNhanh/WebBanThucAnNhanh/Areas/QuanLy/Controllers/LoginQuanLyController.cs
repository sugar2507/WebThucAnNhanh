using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanThucAnNhanh.Models;

namespace WebBanThucAnNhanh.Areas.QuanLy.Controllers
{
    public class LoginQuanLyController : Controller
    {
        // GET: QuanLy/LoginQuanLy
        QLThucAnNhanhEntities database = new QLThucAnNhanhEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoginAccount()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginAccount(ADMIN _user)
        {
            //var user = database.ADMINs.Find(_user.Email);
            var check = database.ADMINs.Where(s => s.Email == _user.Email && s.Pass == _user.Pass).FirstOrDefault();
            if (check == null)
            {
                ViewBag.ErrorInfo = "Sai info";
                return View("Index");
            }
            else
            {
                database.Configuration.ValidateOnSaveEnabled = false;
                Session["Email"] = _user.Email;
                Session["IDQL"] = check.ID;

                return RedirectToAction("Index", "Account");
            }    

                    
        }
        public ActionResult RegisterQuanLy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterQuanLy(ADMIN admin)
        {
            if (ModelState.IsValid)
            {
                var check_ID = database.ADMINs.Where(s => s.Email == admin.Email).FirstOrDefault();
                if (check_ID == null)
                {
                    database.Configuration.ValidateOnSaveEnabled = false;
                    database.ADMINs.Add(admin);
                    database.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorRegister = "This ID is exist";
                    return View();
                }
            }
            return View();
        }
        public ActionResult EditAccount(int ID)
        {
            var detailUser = database.ADMINs.Where(m => m.ID == ID).FirstOrDefault();
            return View(detailUser);
        }

        [HttpPost]
        public ActionResult EditAccount(ADMIN admin)
        {
            var detail = database.ADMINs.Where(m => m.ID == admin.ID);

            if (detail == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                database.Entry(admin).State = EntityState.Modified;
                database.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public bool CheckExistAccount(ADMIN _user)
        {
            var check = database.ADMINs.Where(s => s.Email == _user.Email && s.Pass == _user.Pass).FirstOrDefault();
            if (check != null)
            {
                return true;
            }

            return false;
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "LoginQuanLy");
        }
    }
}