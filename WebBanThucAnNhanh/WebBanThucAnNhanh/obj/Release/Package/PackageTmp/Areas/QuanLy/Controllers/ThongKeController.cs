using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanThucAnNhanh.Models;

namespace WebBanThucAnNhanh.Areas.QuanLy.Controllers
{
    public class ThongKeController : Controller
    {
        QLThucAnNhanhEntities _db = new QLThucAnNhanhEntities();
        // GET: QuanLy/ThongKe
        public ActionResult Index()
        {
            if (Session["IDQL"] == null)
            {
                return RedirectToAction("Index", "LoginQuanLy");
            }
            return View(_db.HOADONs.ToList());
        }

        // GET: QuanLy/ThongKe/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: QuanLy/ThongKe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuanLy/ThongKe/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: QuanLy/ThongKe/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: QuanLy/ThongKe/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: QuanLy/ThongKe/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: QuanLy/ThongKe/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Dữ liệu này đang được sử dụng bởi một bảng khác");
            }
        }
      
    }
}
