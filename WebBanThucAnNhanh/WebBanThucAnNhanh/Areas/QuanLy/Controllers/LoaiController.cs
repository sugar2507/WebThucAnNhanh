using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanThucAnNhanh.Models;

namespace WebBanThucAnNhanh.Areas.QuanLy.Controllers
{
    public class LoaiController : Controller
    {
        QLThucAnNhanhEntities _db = new QLThucAnNhanhEntities();
        // GET: NhanVien/LoaiMon
        public ActionResult Index()
        {
            if (Session["IDQL"] == null)
            {
                return RedirectToAction("Index", "LoginQuanLy");
            }
            return View(_db.LOAIs.ToList());
        }

        // GET: NhanVien/LoaiMon/Details/5
        public ActionResult Details(string id)
        {
            return View(_db.LOAIs.Where(s => s.MALOAI == id).FirstOrDefault());
        }

        // GET: NhanVien/LoaiMon/Create
        public ActionResult Create()
        {
            LOAI loai = new LOAI();
            return View(loai);
        }

        // POST: NhanVien/LoaiMon/Create
        [HttpPost]
        public ActionResult Create(LOAI loai)
        {
            try
            {
                if (ModelState.IsValid)
                // TODO: Add insert logic here
                {
                    _db.LOAIs.Add(loai);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(loai);
            }
            catch
            {
                return View();
            }
        }

        // GET: NhanVien/LoaiMon/Edit/5
        public ActionResult Edit(string id)
        {
            return View(_db.LOAIs.Where(s => s.MALOAI == id).FirstOrDefault()); 
        }

        // POST: NhanVien/LoaiMon/Edit/5
        [HttpPost]
        public ActionResult Edit(LOAI loai,string id)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    _db.Entry(loai).State = EntityState.Modified;
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(loai);
            }
            catch
            {
                return Content("Data đang được sử dụng bởi một bảng khác");
            }
        }

        public ActionResult Delete(string id)
        {
            return View(_db.LOAIs.Where(s => s.MALOAI == id).FirstOrDefault());
        }

        // POST: NhanVien/DonViTinhMon/Delete/5
        [HttpPost]
        public ActionResult Delete(LOAI loai,string id)
        {
            try
            {
                // TODO: Add delete logic here
                loai = _db.LOAIs.Where(s => s.MALOAI == id).FirstOrDefault();
                _db.LOAIs.Remove(loai);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Dữ liệu này đang được sử dụng bởi một bảng khác");
            }
        }

        public PartialViewResult LoaiPartial()
        {
            var loaiList = _db.LOAIs.ToList();
            return PartialView(loaiList);
        }
        // GET: QuanLy/Loai
      
    }
}